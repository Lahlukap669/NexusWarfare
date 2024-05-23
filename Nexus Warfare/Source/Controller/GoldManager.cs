using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_Warfare.Source.Controller
{
    public class GoldManager
    {
        public int TotalGold { get; private set; }

        public GoldManager()
        {
            TotalGold = 0;
        }

        public void EarnGold(int amount)
        {
            TotalGold += amount;
        }

        public bool SpendGold(int amount)
        {
            if (TotalGold >= amount)
            {
                TotalGold -= amount;
                return true; // Transaction successful
            }
            return false; // Not enough gold
        }

        public int GetTotalGold()
        {
            return TotalGold;
        }
        public void Reset()
        {
            TotalGold = 0;
        }
    }
}
