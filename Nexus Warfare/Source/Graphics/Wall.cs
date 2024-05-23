using Android.Telecom;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nexus_Warfare.Source.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Warfare.Source.Graphics
{
    public class Wall:Sprite
    {
        public int HP { get; private set; }
        public Wall(ContentManager content)
            : base(content, "Gameplay Area/wall")
        {
            Position = new Vector2(535, 1300);
            HP = 1000;
        }
        public void TakeDamage(int damage)
        {
            HP -= damage;
            if (HP <= 0)
            {
                Destroy();
            }
        }
        public int GetHealth()
        {
            return HP;
        }

        private void Destroy()
        {
            //handle the destruction of the wall
            Game1.Instance.gameState = GameState.GameOver;
        }

        // Override the Draw and Update methods if necessary
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
