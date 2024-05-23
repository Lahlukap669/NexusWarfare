using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Warfare.Source.Graphics.MonsterTypes
{
    public class SuperMonster : Monster
    {
        public SuperMonster(ContentManager content, Vector2 initialPosition)
            : base(content, "Monster/Monster10/Monster10-animation_00", initialPosition)
        {
            Health = 280;
            Damage = 60;
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
