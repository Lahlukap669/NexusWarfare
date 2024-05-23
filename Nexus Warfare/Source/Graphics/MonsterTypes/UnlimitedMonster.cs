using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Warfare.Source.Graphics.MonsterTypes
{
    public class UnlimitedMonster : Monster
    {
        public UnlimitedMonster(ContentManager content, Vector2 initialPosition)
            : base(content, "Monster/Monster07/Monster07-animation_00", initialPosition)
        {
            Health = 200;
            Damage = 20;
            Speed = 100f;
            Value = 50;

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
