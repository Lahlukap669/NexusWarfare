using Microsoft.Xna.Framework;
using Nexus_Warfare.Source.Controller;
using Nexus_Warfare.Source.Graphics.MonsterTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Warfare.Source.Graphics
{
    public class Wave
    {
        //list of monsters
        public List<Monster> monsters { get; set; }
        public List<MonsterType> monsterTypes = [];
        //kolko monsterjev se naj spawna na spawnpoint
        public int spawnCount { get; set; }
        //koliko katerih se naj spawna na lane

        //čas spawnanja - frekvenca
        public float spawnInterval { get; set; } 
        //dolžina wave
        public float waveDuration { get; set; } 
        public int waveNum { get; set; }

        //private MonsterManager monsterManager;
        private static Random random = new Random();

        //private int timeSinceLastSpawn = 0;
        //private int waveTimer = 0;
        public bool IsComplete { get; set; }
        public List<MonsterType> monsterType { get; set; }


        public float GetWaveDuration()
        {
            return waveDuration;
        }
        public float GetSpawnInterval()
        {
            return spawnInterval;
        }
        public List<MonsterType> GetMonsterTypes() {
            monsterTypes.Clear();
            //monsterTypes list iz Wave1
            for (int i = 0; i < spawnCount; i++)
            {
                //TULE BAJE ZABREJKA - NEKI MU NI VŠEČ GLEDE MONSTERTYPOV
                int randomIndex = random.Next(monsterType.Count);
                //Console.WriteLine(monsterType.Count);
                monsterTypes.Add(monsterType[randomIndex]);   
            }
            return monsterTypes; 
        }
        public int GetSpawnCount() { 
            return spawnCount;
        }
        public int GetWaveNum() { 
            return waveNum;
        }


        public void Update(GameTime gameTime)
        {
            //Tuki pomoje neki fali
        }
    }
}

