using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nexus_Warfare.Source.Graphics;
using static Android.Icu.Text.Transliterator;

namespace Nexus_Warfare.Source.Scene
{
    public class MainMenuScreen
    {
        private Texture2D backgroundTexture;
        private Texture2D logoTexture;
        private Texture2D playButtonTexture;
        private Texture2D exitButtonTexture;

        private Vector2 logoPosition;
        private Rectangle playButtonRectangle;
        private Rectangle exitButtonRectangle;
        private SpriteFont font;
        private int maxCompletedWaves;

        public MainMenuScreen(ContentManager content, SpriteFont font)
        {
            // Load textures
            this.font = font;
            backgroundTexture = content.Load<Texture2D>("User interfaces/landing Screen/cover background");
            logoTexture = content.Load<Texture2D>("User interfaces/landing Screen/game title");
            playButtonTexture = content.Load<Texture2D>("User interfaces/landing Screen/start game btn");
            exitButtonTexture = content.Load<Texture2D>("User interfaces/landing Screen/start game btn");

            // Set positions and rectangles
            logoPosition = new Vector2(40, 300); // Adjust as needed

            playButtonRectangle = new Rectangle(300, 1000, playButtonTexture.Width, playButtonTexture.Height);
            exitButtonRectangle = new Rectangle(300, 1500, exitButtonTexture.Width, exitButtonTexture.Height);
        }

        public void Update(GameTime gameTime, int maxCompletedWaves)
        {
            this.maxCompletedWaves = maxCompletedWaves;
            TouchCollection touchCollection = TouchPanel.GetState();
            foreach (var touch in touchCollection)
            {
                if (touch.State == TouchLocationState.Pressed)
                {
                    if (playButtonRectangle.Contains(touch.Position))
                    {
                        Game1.Instance.gameState = GameState.Play;
                    }
                    else if (exitButtonRectangle.Contains(touch.Position))
                    {
                        Game1.Instance.gameState = GameState.Exit;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, int maxCompletedWaves)
        {
            this.maxCompletedWaves = maxCompletedWaves;
            spriteBatch.Draw(backgroundTexture, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(logoTexture, logoPosition, Color.White);
            spriteBatch.Draw(playButtonTexture, new Vector2(playButtonRectangle.X, playButtonRectangle.Y), Color.White);
            spriteBatch.Draw(exitButtonTexture, new Vector2(exitButtonRectangle.X, exitButtonRectangle.Y), Color.White);
            string startText = "Start Game";
            spriteBatch.DrawString(font, startText, new Vector2(playButtonRectangle.X + playButtonRectangle.Width / 7, playButtonRectangle.Y + playButtonRectangle.Height / 4), Color.Black);
            string endText = "End Game";
            spriteBatch.DrawString(font, endText, new Vector2(exitButtonRectangle.X + playButtonRectangle.Width / 6, exitButtonRectangle.Y + playButtonRectangle.Height / 4), Color.Black);
            
            string WaveText = $"Max wave reached: {this.maxCompletedWaves}";
            spriteBatch.DrawString(font, WaveText, new Vector2(230, 1250), Color.Black);
        }
    }

}
