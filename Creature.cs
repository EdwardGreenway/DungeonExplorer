using DungeonExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class Creature
    {
        protected string name;
        protected int health;
        public bool Alive { get; set; }

        public Creature(string name, int health)
        {
            this.name = name;
            this.health = health;
            Alive = true;
        }
    }
}
