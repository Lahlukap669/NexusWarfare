using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Nexus_Warfare.Source.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Nexus_Warfare.Source.Graphics.MonsterTypes
{
    public class FastMonster : Monster
    {
        public FastMonster(ContentManager content, Vector2 initialPosition)
            : base(content, "Monster/Monster04/Monster04-animation_00", initialPosition)
        {
            Health = 70;
            Damage = 10;
            Speed = 150f;
            Value = 15;

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
