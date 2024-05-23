using Microsoft.Xna.Framework;
using Nexus_Warfare.Source.Graphics.MonsterTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Warfare.Source.Graphics.WavesLevels
{
    public class Wave7 : Wave
    {
        public Wave7()
        {
            waveNum = 7;
            waveDuration = 180.0f;
            spawnCount = 6;
            spawnInterval = 5.0f;
            monsterType = [ MonsterType.UltimateMonster, MonsterType.UnlimitedMonster, MonsterType.BossMonster];
        }
        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
