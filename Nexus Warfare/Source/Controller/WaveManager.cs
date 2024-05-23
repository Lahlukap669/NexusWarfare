using Javax.Security.Auth;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Nexus_Warfare.Source.Graphics;
using Nexus_Warfare.Source.Graphics.MonsterTypes;
using Nexus_Warfare.Source.Graphics.WavesLevels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Java.Interop.JniEnvironment;

namespace Nexus_Warfare.Source.Controller
{
    public class WaveManager
    {
        private MonsterManager monsterManager;
        //private Random random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
        //private List<WaveLevel> waveLevel;

        //definicije Wave
        private Wave wave;
        //private float waveDuration = 60.0f; // 1 minute
        //private float spawnInterval = 5.0f; // Spawn a monster every 5 seconds
        private float timeSinceLastSpawn;
        private float waveTimer;
        private float waveDuration;
        //private float spawnInterval;
        //private int spawnCount;
        private int waveNum;
        private int currentWaveLevel = 0;
        private List<MonsterType> monsterTypes;

        public WaveManager(MonsterManager monsterManager, WaveLevel waveLevel)
        {
            SelectWave(waveLevel);
            this.monsterManager = monsterManager;
        }

        public void StartWave()
        {
            waveTimer = 0;
            timeSinceLastSpawn = 0;
        }
        public int GetWaveNumber()
        {
            //waveDuration = wave.GetWaveDuration();
            waveNum = wave.GetWaveNum();
            return waveNum;
        }

        public void Update(GameTime gameTime)
        {
            waveTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            timeSinceLastSpawn += (float)gameTime.ElapsedGameTime.TotalSeconds;
            waveDuration = wave.GetWaveDuration();
            wave.Update(gameTime);

            if (waveTimer < waveDuration)
            {
                if (timeSinceLastSpawn >= wave.GetSpawnInterval())
                {
                    
                    SpawnMonster();
                    timeSinceLastSpawn = 0;
                }
            }
            else
            {
                currentWaveLevel = wave.GetWaveNum();
                if (currentWaveLevel == 10)
                {
                    Game1.Instance.gameState = Scene.GameState.GameOver;
                }
                else
                {
                    waveTimer = 0;
                    WaveLevel nextWaveLevel = (WaveLevel)currentWaveLevel;
                    SelectWave(nextWaveLevel);
                }
            }           

        }

        private void SpawnMonster()
        {
            monsterTypes = wave.GetMonsterTypes();
            for (int i = 0; i < monsterTypes.Count; i++)
            {
                Random random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
                MonsterType type = monsterTypes[i];
                int lane = random.Next(0, 6);
                monsterManager.AddMonster(type, lane);
            }
        }
        public void Reset()
        {
            waveNum = 1;
            currentWaveLevel = 0;
            waveTimer = 0;
            timeSinceLastSpawn = 0;
        }
        public void SelectWave(WaveLevel waveLevel)
        {
            switch (waveLevel)
            {
                case WaveLevel.Wave1:
                    wave = new Wave1();
                    break;
                case WaveLevel.Wave2:
                    wave = new Wave2();
                    break;
                case WaveLevel.Wave3:
                    wave = new Wave3();
                    break;
                case WaveLevel.Wave4:
                    wave = new Wave4();
                    break;
                case WaveLevel.Wave5:
                    wave = new Wave5();
                    break;
                case WaveLevel.Wave6:
                    wave = new Wave6();
                    break;
                case WaveLevel.Wave7:
                    wave = new Wave7();
                    break;
                case WaveLevel.Wave8:
                    wave = new Wave8();
                    break;
                case WaveLevel.Wave9:
                    wave = new Wave9();
                    break;
                case WaveLevel.Wave10:
                    wave = new Wave10();
                    break;
                default:
                    break;
            }
        }
    }
}
