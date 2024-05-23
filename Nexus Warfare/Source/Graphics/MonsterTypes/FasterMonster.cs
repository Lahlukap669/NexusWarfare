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
    public class FasterMonster : Monster
    {
        public FasterMonster(ContentManager content, Vector2 initialPosition)
            : base(content, "Monster/Monster05/Monster05-animation_00", initialPosition)
        {
            Health = 60;
            Damage = 15;
            Speed = 160f;
            Value = 20;

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
