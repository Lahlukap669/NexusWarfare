using Android.Widget;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using Nexus_Warfare.Source.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Warfare.Source.Scene
{
    public class HUD
    {
        private SpriteFont font;
        private Vector2 position;
        private int score;
        private int health;
        //private Vector2 buttonPosition;
        Texture2D pauseButtonTexture;
        Rectangle pauseButtonRectangle;
        Texture2D shopButtonTexture;
        Rectangle shopButtonRectangle;
        private GoldManager goldManager;
        private TurretManager turretManager;


        public HUD(SpriteFont font, ContentManager Content, GoldManager goldManager, TurretManager turretManager)
        {
            this.font = font;
            this.score = 0;
            this.health = 100; // Assuming 100 is the starting health
            this.position = new Vector2(10, 1920);
            this.goldManager = goldManager;
            this.turretManager = turretManager;
            pauseButtonTexture = Content.Load<Texture2D>("User interfaces/game play area Ui/pause btn");
            pauseButtonRectangle = new Rectangle(870, 1900, pauseButtonTexture.Width, pauseButtonTexture.Height);
            //pauseButtonRectangle = new Rectangle(870, 1700, pauseButtonTexture.Width, pauseButtonTexture.Height);
            shopButtonTexture = Content.Load<Texture2D>("User interfaces/game play area Ui/shop btn");
            shopButtonRectangle = new Rectangle(680, 1900, shopButtonTexture.Width, shopButtonTexture.Height);
            //shopButtonRectangle = new Rectangle(680, 1700, shopButtonTexture.Width, shopButtonTexture.Height);
        }

        public void Update(int score, int health, TouchCollection touchCollection)
        {
            //Console.WriteLine("Sm še prije");
            this.score = score;
            this.health = health;
            foreach (var touch in touchCollection)
            {
                if (touch.State == TouchLocationState.Pressed)
                {
                    if (pauseButtonRectangle.Contains(touch.Position))
                    {
                        Game1.Instance.gameState = GameState.Pause;
                    }
                    else if (shopButtonRectangle.Contains(touch.Position)) 
                    {
                        //Add functionality za addGun
                        if (turretManager.CanPlaceTurretOnBackline()) {
                            if (goldManager.SpendGold(100))
                            { turretManager.PlaceTurretOnBackline(); }
                        }
                        else { Console.WriteLine("Can't buy gun..."); }
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            string hudText = $"Wave: {score}  Health: {health}";
            spriteBatch.DrawString(font, hudText, position, Color.White);
            string goldText = $"Gold: {goldManager.GetTotalGold()}";
            spriteBatch.DrawString(font, goldText, new Vector2(10, 1990), Color.White);
            spriteBatch.Draw(pauseButtonTexture, new Vector2(pauseButtonRectangle.X, pauseButtonRectangle.Y), Color.White);
            spriteBatch.Draw(shopButtonTexture, new Vector2(shopButtonRectangle.X, shopButtonRectangle.Y), Color.White);
        }
    }

}
