using Microsoft.Xna.Framework;
using Nexus_Warfare.Source.Graphics.MonsterTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Warfare.Source.Graphics.WavesLevels
{
    public class Wave2 : Wave
    {
        public Wave2()
        {
            waveNum = 2;
            waveDuration = 100.0f;
            spawnCount = 6;
            spawnInterval = 7.0f;
            monsterType = [MonsterType.NormalMonster, MonsterType.FastMonster, MonsterType.FasterMonster];
        }
        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
