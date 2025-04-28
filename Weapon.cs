using DungeonExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// This is the class for Weapon objects
    /// It has inherited from the abstract Item class
    /// </summary>
    public class Weapon : Item
    {
        public int Damage { get; }
        public int Speed { get; }

        public Weapon(string name, int quality, int damage, int speed) : base(name, quality)
        {
            this.Damage = damage;
            this.Speed = speed;
        }
    }
}
