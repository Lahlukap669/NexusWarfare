using Microsoft.Xna.Framework;
using Nexus_Warfare.Source.Graphics.MonsterTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Warfare.Source.Graphics.WavesLevels
{
    public class Wave4 : Wave
    {
        public Wave4()
        {
            waveNum = 4;
            waveDuration = 140.0f;
            spawnCount = 6;
            spawnInterval = 7.0f;
            monsterType = [MonsterType.FasterMonster, MonsterType.UltimateMonster];
        }
        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
