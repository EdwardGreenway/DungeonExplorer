using DungeonExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// This class is a derivative of the abstract item class
    /// It stores the properties for potions
    /// Currently, healing potions are the only ones available
    /// </summary>
    public class Potion : Item
    {
        public int HealingAmount { get; }

        public Potion(string name, int quality, int healingAmount) : base(name, quality)
        {
            this.HealingAmount = healingAmount;
        }
    }
}
