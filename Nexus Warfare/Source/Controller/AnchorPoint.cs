using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Warfare.Source.Controller
{
    public class AnchorPoint
    {
        public Vector2 Position { get; private set; }
        public bool IsOccupied { get; set; }
        public bool IsActive { get; set; }

        public AnchorPoint(Vector2 position, bool isActive = false)
        {
            Position = position;
            IsOccupied = false;
            IsActive = isActive;
        }

    }
}
