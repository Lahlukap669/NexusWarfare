using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Nexus_Warfare.Source.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Warfare.Source.Controller
{
    public class MonsterSpawnPoint
    {
        public Vector2 Position { get; private set; }
        public MonsterSpawnPoint(Vector2 position)
        {
            Position = position;
        }
    }
}
