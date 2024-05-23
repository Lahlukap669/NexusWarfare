using Android.Graphics.Drawables;
using Android.Graphics;
using Android.OS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Android.Graphics.Paint;

namespace Nexus_Warfare.Source.Graphics
{
    public class Coin : Sprite
    {
        public int Value { get; private set; }
        public bool IsCollected { get; private set; }

        public Coin(ContentManager content, Vector2 position, int value)
            : base(content, "User interfaces/offline earning popup/coin bonus icon")
        {
            Value = value;
            Position = position;
            IsCollected = false;
        }

        public void Collect()
        {
            IsCollected = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!IsCollected)
            {
                base.Draw(spriteBatch);
            }
        }
    }
}
