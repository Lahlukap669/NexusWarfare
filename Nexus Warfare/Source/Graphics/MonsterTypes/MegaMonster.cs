using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Warfare.Source.Graphics.MonsterTypes
{
    public class MegaMonster : Monster
    {
        public MegaMonster(ContentManager content, Vector2 initialPosition)
            : base(content, "Monster/Monster02/Monster02-animation_00", initialPosition)
        {
            Health = 300;
            Damage = 80;
            Speed = 110f;
            Value = 90;

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
