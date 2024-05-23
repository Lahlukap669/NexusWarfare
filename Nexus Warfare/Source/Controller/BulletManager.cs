using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Nexus_Warfare.Source.Graphics;


namespace Nexus_Warfare.Source.Controller
{

    public class BulletManager
    {
        public List<Bullet> bullets { get; set; }
        private ContentManager content;
        private String bulletTexture;

        public BulletManager(ContentManager Content)
        {
            //create different bullet types 
            bullets = new List<Bullet>();
            content = Content;
            bulletTexture = "Bullets/5";
        }
        public List<Bullet> GetBullets()
        {
            return bullets;
        }

        public void CreateBullet(Vector2 position, float speed, int damage)
        {
            Bullet newBullet = new Bullet(content,bulletTexture, position, speed, damage);
            bullets.Add(newBullet);
        }

        public void Update(GameTime gameTime)
        {
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                Bullet bullet = bullets[i];
                bullet.Update(gameTime);

                if (!bullet.IsActive)
                {
                    bullets.RemoveAt(i);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var bullet in bullets)
            {
                bullet.Draw(spriteBatch);
            }
        }
    }

}
