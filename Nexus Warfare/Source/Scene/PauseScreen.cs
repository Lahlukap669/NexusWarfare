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
    public class PauseScreen
    {
        private Texture2D backgroundTexture;
        private Texture2D resumeButtonTexture;
        private Texture2D exitButtonTexture;

        private Rectangle resumeButtonRectangle;
        private Rectangle exitButtonRectangle;
        private SpriteFont font;

        public PauseScreen(ContentManager content, SpriteFont font)
        {
            // Load textures
            this.font = font;
            backgroundTexture = content.Load<Texture2D>("User interfaces/landing Screen/cover box ");
            resumeButtonTexture = content.Load<Texture2D>("User interfaces/landing Screen/start game btn");
            exitButtonTexture = content.Load<Texture2D>("User interfaces/landing Screen/start game btn");

            // Set positions and rectangles

            exitButtonRectangle = new Rectangle(300, 1100, exitButtonTexture.Width, exitButtonTexture.Height);
            resumeButtonRectangle = new Rectangle(300, 800, resumeButtonTexture.Width, resumeButtonTexture.Height);
        }

        public void Update(GameTime gameTime)
        {
            TouchCollection touchCollection = TouchPanel.GetState();
            foreach (var touch in touchCollection)
            {
                if (touch.State == TouchLocationState.Pressed)
                {
                    if (resumeButtonRectangle.Contains(touch.Position))
                    {
                        Game1.Instance.gameState = GameState.Play;
                    }
                    else if (exitButtonRectangle.Contains(touch.Position))
                    {
                        Game1.Instance.gameState = GameState.GameOver;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, int waveNum)
        {
            spriteBatch.Draw(backgroundTexture, new Vector2(0, backgroundTexture.Height / 2), Color.White);
            spriteBatch.Draw(resumeButtonTexture, new Vector2(resumeButtonRectangle.X, resumeButtonRectangle.Y), Color.White);
            spriteBatch.Draw(exitButtonTexture, new Vector2(exitButtonRectangle.X, exitButtonRectangle.Y), Color.White);
            string startText = "Resume";
            spriteBatch.DrawString(font, startText, new Vector2(resumeButtonRectangle.X + resumeButtonRectangle.Width / 4, resumeButtonRectangle.Y + resumeButtonRectangle.Height / 4), Color.Black);
            string endText = "End Game";
            spriteBatch.DrawString(font, endText, new Vector2(exitButtonRectangle.X + exitButtonRectangle.Width / 6, exitButtonRectangle.Y + exitButtonRectangle.Height / 4), Color.Black);
            string PauseMenuText = "Pause Menu";
            spriteBatch.DrawString(font, PauseMenuText, new Vector2(350,  650), Color.Black);
            string WaveText = $"Total Waves: {waveNum}";
            spriteBatch.DrawString(font, WaveText, new Vector2(320, 1350), Color.Black);

        }
    }

}
