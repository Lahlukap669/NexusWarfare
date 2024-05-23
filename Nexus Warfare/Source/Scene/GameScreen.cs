using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Android.App.Roles;
using Android.App;
using Android.Content;
using Android.Telecom;
using Android.Widget;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using Nexus_Warfare.Source.Controller;
using Nexus_Warfare.Source.Graphics;
using Nexus_Warfare.Source.Graphics.WavesLevels;
using static Android.Icu.Text.Transliterator;
using static Java.Interop.JniEnvironment;

namespace Nexus_Warfare.Source.Scene
{

    public class GameScreen
    {
        private TurretManager turretManager; // The manager for the turrets
        private MonsterManager monsterManager; // The manager for the monsters
        private Texture2D backgroundTexture; // Texture for the background
        private Rectangle screenBounds; // The bounds of the screen
        private ContentManager content; // The Content Manager
        private Wall wall; // The wall
        private WaveManager waveManager;
        private HUD hud;
        private SoundManager soundManager;
        private float damageTimer;
        private float damageInterval = 1.0f;
        private Rectangle backgroundBounds;
        private GoldManager goldManager;
        public GameScreen(Rectangle screenBounds, GoldManager goldManager)
        {
            this.screenBounds = screenBounds;
            this.goldManager = goldManager;

        }

        public void LoadContent(ContentManager contentManager)
        {
            content = contentManager;
            // Load the background image
            backgroundTexture = content.Load<Texture2D>("Gameplay Area/game area");
            wall = new Wall(content);
            backgroundBounds = new Rectangle(0, 0, screenBounds.Width, screenBounds.Height);
            // Initialize the monster manager with spawn positions
            monsterManager = new MonsterManager(content);
            turretManager = new TurretManager(content);
            waveManager = new WaveManager(monsterManager, WaveLevel.Wave1);
            hud = new HUD(Game1.Instance.Font, content, goldManager, turretManager);
            soundManager = Game1.Instance.soundManager;
            soundManager.LoadSound(content, "83976__theredshore__punch", "BulletHit");
            waveManager.StartWave();
        }

        public void Update(GameTime gameTime)
        {
            TouchCollection touchCollection = TouchPanel.GetState();
            turretManager.HandleInput(touchCollection);
            Game1.Instance.coinManager.Update(gameTime, touchCollection);
            turretManager.Update(gameTime);
            monsterManager.Update(gameTime);
            waveManager.Update(gameTime);
            hud.Update(waveManager.GetWaveNumber(), wall.GetHealth(), touchCollection);
            
            damageTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (var turret in turretManager.GetTurrets())
            {
                foreach(var bullet in turret.GetBullets())
                {
                    foreach(var monster in monsterManager.GetMonsters())
                    {
                        
                        if (CheckCollision(bullet, monster))
                        {
                            monster.TakeDamage(bullet.GetDamage());
                            bullet.SetIsActive(false);
                            soundManager.PlaySound("BulletHit");
                        }
                        // Apply wall damage at intervals
                    }   

                }
            }
            if (damageTimer >= damageInterval)
            {
                foreach (var monster in monsterManager.GetMonsters())
                {
                    if (CheckCollision(monster, wall))
                    {
                        wall.TakeDamage(monster.GetDamage());
                    }
                }
                damageTimer = 0f; // Reset the timer after processing all monsters
            }

        }
        public bool CheckCollision(Sprite spriteA, Sprite spriteB)
        {
            return spriteA.Bounds.Intersects(spriteB.Bounds);
        }
        public int getWaveNum()
        {
            return waveManager.GetWaveNumber();
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(backgroundTexture, backgroundBounds, Color.White);

            monsterManager.Draw(spriteBatch);

            wall.Draw(spriteBatch);

            turretManager.Draw(spriteBatch);

            hud.Draw(spriteBatch);

            Game1.Instance.coinManager.Draw(spriteBatch);

        }
        public void Reset()
        {
            // Reinitialize or reset the monster manager
            monsterManager = new MonsterManager(content);
            waveManager = new WaveManager(monsterManager, WaveLevel.Wave1);

            // Reinitialize or reset the turret manager
            turretManager = new TurretManager(content);

            // Reset the wall's health or state
            wall = new Wall(content);

            // Reinitialize the wave manager and start from the first wave
            waveManager = new WaveManager(monsterManager, WaveLevel.Wave1);
            waveManager.StartWave();

            // Reset the HUD
            hud = new HUD(Game1.Instance.Font, content, goldManager, turretManager);

            // Reset the damage timer
            damageTimer = 0f;
        }
    }
}
