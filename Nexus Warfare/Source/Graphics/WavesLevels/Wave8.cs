using Microsoft.Xna.Framework;
using Nexus_Warfare.Source.Graphics.MonsterTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Warfare.Source.Graphics.WavesLevels
{
    public class Wave8 : Wave
    {
        public Wave8()
        {
            waveNum = 8;
            waveDuration = 200.0f;
            spawnCount = 8;
            spawnInterval = 6.0f;
            monsterType = [MonsterType.UnlimitedMonster, MonsterType.BossMonster];
        }
        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
