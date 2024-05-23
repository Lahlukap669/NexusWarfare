using Microsoft.Xna.Framework;
using Nexus_Warfare.Source.Graphics.MonsterTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Warfare.Source.Graphics.WavesLevels
{
    public class Wave9 : Wave
    {
        public Wave9()
        {
            waveNum = 9;
            waveDuration = 230.0f;
            spawnCount = 5;
            spawnInterval = 6.0f;
            monsterType = [MonsterType.BossMonster, MonsterType.SuperMonster];
        }
        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
