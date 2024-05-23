using Microsoft.Xna.Framework.Content;
using Nexus_Warfare.Source.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Android.Widget.GridLayout;

namespace Nexus_Warfare.Source.Graphics.MonsterTypes
{
    public class NormalMonster : Monster
    {
        public NormalMonster(ContentManager content, Vector2 initialPosition)
            : base(content, "Monster/Monster01/Monster01-animation_00", initialPosition)
        {

            Health = 100;
            Damage = 10;
            Speed = 90f;
            Value = 10;

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void ActivateAbility()
        {

        }
    }
}
