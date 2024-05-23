using Microsoft.Xna.Framework;
using Nexus_Warfare.Source.Controller;
using Nexus_Warfare.Source.Graphics.MonsterTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Warfare.Source.Graphics.WavesLevels
{
    public class Wave1 : Wave
    {
        public Wave1() {
            waveNum = 1;
            waveDuration = 90.0f;
            spawnCount = 6;
            spawnInterval = 10.0f;
            monsterType = [MonsterType.NormalMonster, MonsterType.FastMonster];
        }
        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
