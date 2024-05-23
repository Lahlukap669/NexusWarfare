using Microsoft.Xna.Framework;
using Nexus_Warfare.Source.Graphics.MonsterTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Warfare.Source.Graphics.WavesLevels
{
    public class Wave6 : Wave
    {
        public Wave6()
        {
            waveNum = 6;
            waveDuration = 180.0f;
            spawnCount = 8;
            spawnInterval = 5.0f;
            monsterType = [MonsterType.FasterMonster, MonsterType.UltimateMonster, MonsterType.UnlimitedMonster];
        }
        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
