using DungeonExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Potion : Item
    {
        public int HealingAmount { get; }

        public Potion(string name, int quality, int healingAmount) : base(name, quality)
        {
            this.HealingAmount = healingAmount;
        }
    }
}
