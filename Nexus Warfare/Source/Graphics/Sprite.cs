using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Warfare.Source.Graphics
{
    public class Sprite
    {
        public Texture2D Texture;
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public Vector2 Origin { get; private set; }
        public float Scale { get; set; } = 1f;

        public Rectangle Bounds
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            }
        }

        public Sprite(ContentManager content, string assetName = null)
        {
            // Load the texture and set the origin to its center
            if (assetName != null)
            {
                Texture = content.Load<Texture2D>(assetName);
                Origin = new Vector2(Texture.Width / 2f, Texture.Height / 2f);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if(Texture == null)
            {
                return;
            }
            // Draw the sprite with the origin at its center
            spriteBatch.Draw(Texture, Position, null, Color.White, Rotation, Origin, Scale, SpriteEffects.None, 0f);
        }
    }
}
