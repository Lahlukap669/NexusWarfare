using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Nexus_Warfare.Source.Graphics;
using Nexus_Warfare.Source.Graphics.MonsterTypes;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Nexus_Warfare.Source.Controller
{
    public class MonsterManager
    {   
        private List<Monster> monsters;
        private List<MonsterSpawnPoint> spawnPoints;
        private ContentManager contentManager;
        private List<Monster> monstersToRemove = new List<Monster>();

        public MonsterManager(ContentManager content)
        {
            monsters = new List<Monster>();
            contentManager = content;
            spawnPoints = new List<MonsterSpawnPoint>();
            InitializeSpawnPoints();
        }

        public void InitializeSpawnPoints()
        {
            // Define the spawn points here
            spawnPoints = new List<MonsterSpawnPoint>();
            spawnPoints.Add(new MonsterSpawnPoint(new Vector2(170, 0)));
            spawnPoints.Add(new MonsterSpawnPoint(new Vector2(325, 0)));
            spawnPoints.Add(new MonsterSpawnPoint(new Vector2(470, 0)));
            spawnPoints.Add(new MonsterSpawnPoint(new Vector2(605, 0)));
            spawnPoints.Add(new MonsterSpawnPoint(new Vector2(750, 0)));
            spawnPoints.Add(new MonsterSpawnPoint(new Vector2(895, 0)));
        }
        public void AddMonster(MonsterType monsterType, int lane)
        {
            switch (monsterType)
            {
                case MonsterType.NormalMonster:
                    monsters.Add(new NormalMonster(contentManager, spawnPoints[lane].Position));
                    break;
                case MonsterType.FastMonster:
                    monsters.Add(new FastMonster(contentManager, spawnPoints[lane].Position));
                    break;
                case MonsterType.FasterMonster:
                    monsters.Add(new FasterMonster(contentManager, spawnPoints[lane].Position));
                    break;
                case MonsterType.UltimateMonster:
                    monsters.Add(new UltimateMonster(contentManager, spawnPoints[lane].Position));
                    break;
                case MonsterType.UnlimitedMonster:
                    monsters.Add(new UnlimitedMonster(contentManager, spawnPoints[lane].Position));
                    break;
                default:
                    break;
            }
        }

        public List<Monster> GetMonsters()
        {
            return monsters;
        }
     
        public void Update(GameTime gameTime)
        {
            foreach (Monster monster in monsters)
            {
                monster.Update(gameTime);
                if (!monster.IsActive)
                {
                    monstersToRemove.Add(monster);
                }
            }
            foreach (Monster monster in monstersToRemove)
            {
                monsters.Remove(monster);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Monster monster in monsters)
            {
                monster.Draw(spriteBatch);
            }
        }
    }
}
