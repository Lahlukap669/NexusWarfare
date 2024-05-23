using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Android.Icu.Text.Transliterator;
using Java.Lang.Annotation;
using static Android.Widget.GridLayout;
using Microsoft.Xna.Framework.Content;
using Nexus_Warfare.Source.Controller;
using Java.Util.Logging;
using Java.Security;
using Android.Gestures;

namespace Nexus_Warfare.Source.Graphics
{
    public class Turret : Sprite
    {
        public bool isActive { get; set; }
        public AnchorPoint CurrentAnchor { get; set; }
        public BulletManager bulletManager { get; set; }
        public int Level { get; set; }
        public float AttackSpeed = 1.5f;
        public int BulletCount { get; set; }
        public Texture2D[] LevelTextures { get; set; }
        public Texture2D texture { get; set; }
        private TimeSpan lastFireTime;
        private SoundManager soundManager;
        //For best balance set to 15
        private float damage = 15;


        public Turret(ContentManager content, String assetName, AnchorPoint currentAnchor, Texture2D[] levelTextures, int level = 0)
            : base(content, assetName)
        {
            Level = level;
            CurrentAnchor = currentAnchor;
            Position = CurrentAnchor.Position;
            isActive = CurrentAnchor.IsActive;
            bulletManager =  new BulletManager(content);
            LevelTextures = levelTextures;
            SetTexture(Level); 
            soundManager = Game1.Instance.soundManager;
            soundManager.LoadSound(content, "348164__djfroyd__laser-one-shot-1", "Fire");
        }
        

        public BulletManager GetBulletManager()
        {
            return bulletManager;
        }
        public List<Bullet> GetBullets()
        {
            return bulletManager.GetBullets();
        }
        private void SetTexture(int level)
        {
            if (level >= 0 && level < LevelTextures.Length)
            {
                this.Texture = LevelTextures[level];
            }
        }

        public Rectangle GetBoundingRectangle()
        {
            int width = (int)(Texture.Width * Scale);
            int height = (int)(Texture.Height * Scale);
            int x = (int)(Position.X - width / 2);
            int y = (int)(Position.Y - height / 2);

            return new Rectangle(x, y, width, height);
        }
        public void Fire()
        {
            Vector2 bulletPosition = Position; 
            Vector2 bulletDirection = new Vector2(0, -1);
            float bulletSpeed = 300;
            // Fix the create bullet method implement bullet type spawning
            bulletManager.CreateBullet(bulletPosition,bulletSpeed, (int)damage);
            soundManager.PlaySound("Fire");
        }

        private void CalculateDamage()
        {
            damage = damage * 1.4f;
        }
        private void CalculateAttackSpeed()
        {
            AttackSpeed = AttackSpeed/1.1f;
        }

        //Guns with two turrets
        private int CalculateBulletCount(int level)
        {
            return 1;
        }
        public void Upgrade()
        {
            if (Level < LevelTextures.Length - 1)
            {
                Level++;
                if (Level == 9)
                { //skip texture get cause we dont want duble turrets
                }
                else
                {
                    this.Texture = LevelTextures[Level];
                }
            }
            CalculateAttackSpeed();
            CalculateDamage();
        }


        public void Update(GameTime gameTime)
        {
            if(CurrentAnchor != null&& isActive == true)
            {
                TimeSpan fireInterval = TimeSpan.FromSeconds(AttackSpeed);
                    
                if (gameTime.TotalGameTime - lastFireTime > fireInterval)
                {
                    // check if there is a bettere way to fire bullets of pasted time
                    Fire();
                    lastFireTime = gameTime.TotalGameTime;
                }
            }
            bulletManager.Update(gameTime);
        }   

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            bulletManager.Draw(spriteBatch);
        }
    }


}
