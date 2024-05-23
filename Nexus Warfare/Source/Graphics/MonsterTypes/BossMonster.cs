using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Warfare.Source.Graphics.MonsterTypes
{
    public class BossMonster : Monster
    {
        public BossMonster(ContentManager content, Vector2 initialPosition)
            : base(content, "Monster/Monster08/Monster08-animation_00", initialPosition)
        {
            Health = 250;
            Damage = 30;
            Speed = 100f;
            Value = 60;

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