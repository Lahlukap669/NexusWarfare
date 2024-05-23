using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Warfare.Source.Scene
{
    internal class EndGameScreen
    {
        private Texture2D backgroundTexture;
        //private Texture2D tryAgainButtonTexture;
        private Texture2D MainMenuButtonTexture;

        //private Rectangle tryAgainButtonRectangle;
        private Rectangle MainMenuButtonRectangle;
        private SpriteFont font;
        private int completedWaves;

        public EndGameScreen(ContentManager content, SpriteFont font)
        {
            // Load textures
            this.font = font;
            backgroundTexture = content.Load<Texture2D>("User interfaces/landing Screen/cover box ");
            //tryAgainButtonTexture = content.Load<Texture2D>("User interfaces/landing Screen/start game btn");
            MainMenuButtonTexture = content.Load<Texture2D>("User interfaces/landing Screen/start game btn");

            // Set positions and rectangles

            MainMenuButtonRectangle = new Rectangle(300, 950, MainMenuButtonTexture.Width, MainMenuButtonTexture.Height);
            //tryAgainButtonRectangle = new Rectangle(300, 950, tryAgainButtonTexture.Width, tryAgainButtonTexture.Height);
        }

        public void Update(GameTime gameTime, int completedWaves)
        {
            this.completedWaves = completedWaves;
            TouchCollection touchCollection = TouchPanel.GetState();
            foreach (var touch in touchCollection)
            {
                if (touch.State == TouchLocationState.Pressed)
                {
                    if (MainMenuButtonRectangle.Contains(touch.Position))
                    {
                        Game1.Instance.gameState = GameState.MainMenu;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, int waveNum)
        {
            this.completedWaves = waveNum;
            spriteBatch.Draw(backgroundTexture, new Vector2(0, backgroundTexture.Height / 2), Color.White);
            //spriteBatch.Draw(tryAgainButtonTexture, new Vector2(tryAgainButtonRectangle.X, tryAgainButtonRectangle.Y), Color.White);
            spriteBatch.Draw(MainMenuButtonTexture, new Vector2(MainMenuButtonRectangle.X, MainMenuButtonRectangle.Y), Color.White);
            string endText = "Main Menu";
            spriteBatch.DrawString(font, endText, new Vector2(MainMenuButtonRectangle.X + MainMenuButtonRectangle.Width / 6, MainMenuButtonRectangle.Y + MainMenuButtonRectangle.Height / 4), Color.Black);
            string PauseMenuText = "Game Over";
            spriteBatch.DrawString(font, PauseMenuText, new Vector2(350, 650), Color.Black);
            string WaveText = $"Total Waves: {waveNum}";
            spriteBatch.DrawString(font, WaveText, new Vector2(320, 1350), Color.Black);

        }
    }
}

