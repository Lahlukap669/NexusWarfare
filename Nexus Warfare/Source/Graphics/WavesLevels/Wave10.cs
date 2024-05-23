using Microsoft.Xna.Framework;
using Nexus_Warfare.Source.Graphics.MonsterTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Warfare.Source.Graphics.WavesLevels
{
    public class Wave10 : Wave
    {
        public Wave10()
        {
            waveNum = 10;
            waveDuration = 400.0f;
            spawnCount = 7;
            spawnInterval = 7.0f;
            monsterType = [MonsterType.BossMonster, MonsterType.SuperMonster, MonsterType.MegaMonster];
        }
        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
