using Microsoft.Xna.Framework;
using Nexus_Warfare.Source.Graphics.MonsterTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Warfare.Source.Graphics.WavesLevels
{
    public class Wave5 : Wave
    {
        public Wave5()
        {
            waveNum = 5;
            waveDuration = 160.0f;
            spawnCount = 6;
            spawnInterval = 5.0f;
            monsterType = [MonsterType.FasterMonster, MonsterType.UltimateMonster, MonsterType.UnlimitedMonster];
        }
        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
