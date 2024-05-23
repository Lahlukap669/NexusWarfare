using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using Nexus_Warfare.Source.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Warfare.Source.Controller
{
    public class CoinManager
    {
        private List<Coin> coins;
        private ContentManager content;
        private GoldManager goldManager; // Reference to GoldManager

        public CoinManager(ContentManager content, GoldManager goldManager)
        {
            this.content = content;
            this.goldManager = goldManager; // Initialize GoldManager
            coins = new List<Coin>();
        }

        public void AddCoin(Coin coin)
        {
            coins.Add(coin);
        }
        public void Reset()
        {
            coins.Clear();
        }

        public void Update(GameTime gameTime, TouchCollection touchCollection)
        {
            foreach (var touch in touchCollection)
            {
                if (touch.State == TouchLocationState.Pressed)
                {
                    Vector2 touchPosition = touch.Position;

                    // Use LINQ to find and collect all coins under the touch position
                    var coinsToCollect = coins.Where(coin => !coin.IsCollected && coin.Bounds.Contains(touchPosition)).ToList();
                    foreach (var coin in coinsToCollect)
                    {
                        coin.Collect();
                        goldManager.EarnGold(coin.Value); // Update GoldManager when coin is collected
                    }
                }
            }

            // Remove collected coins
            coins.RemoveAll(c => c.IsCollected);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var coin in coins)
            {
                if (!coin.IsCollected)
                {
                    coin.Draw(spriteBatch);
                }
            }
        }
    }
}
