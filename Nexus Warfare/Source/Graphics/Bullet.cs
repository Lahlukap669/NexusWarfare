using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Warfare.Source.Graphics
{
    public class Bullet:Sprite
    {
        public float Speed { get; set; }
        public bool IsActive { get; set; }
        public int Damage { get; set; }


        public Bullet(ContentManager content, string assetName, Vector2 initialPosition, float speed, int damage): base(content, assetName)
        {
            Position = initialPosition;
            Speed = speed;
            IsActive = true;
            Damage = damage;
        }
        public int GetDamage()
        {
            return Damage;
        }
        public void SetIsActive(bool isActive)
        {
            IsActive = isActive;
        }

        public void Update(GameTime gameTime)
        {
            Vector2 newPosition = Position;
            newPosition.Y -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position = newPosition;

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsActive)
            {
                base.Draw(spriteBatch);
            }
        }
    }

}
