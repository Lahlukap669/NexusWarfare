using Microsoft.Xna.Framework;
using Nexus_Warfare.Source.Graphics.MonsterTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Warfare.Source.Graphics.WavesLevels
{
    public class Wave3 : Wave
    {
        public Wave3()
        {
            waveNum = 3;
            waveDuration = 120.0f;
            spawnCount = 7;
            spawnInterval = 7.0f;
            monsterType = [MonsterType.FastMonster, MonsterType.FasterMonster];
        }
        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
