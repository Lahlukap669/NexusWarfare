using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Android.Renderscripts.Sampler;
using static Android.Widget.GridLayout;

namespace Nexus_Warfare.Source.Graphics.MonsterTypes
{
    public class UltimateMonster : Monster
    {
        public UltimateMonster(ContentManager content, Vector2 initialPosition)
            : base(content, "Monster/Monster06/Monster06-animation_00", initialPosition)
        {
            Health = 150;
            Damage = 10;
            Speed = 150f;
            Value = 25;

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
