using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Warfare.Source.Graphics.MonsterTypes
{
    public class GlichedMonster : Monster
    {
        public GlichedMonster(ContentManager content, Vector2 initialPosition)
            : base(content, "Monster/Monster09/Monster09-animation_00", initialPosition)
        {
            Health = 180;
            Damage = 60;
            Speed = 130f;
            Value = 70;

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
