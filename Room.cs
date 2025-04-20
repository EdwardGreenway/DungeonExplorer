using DungeonExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Room
    {
        public string Name { get; }
        public int Difficulty { get; }

        public Room(string name, int difficulty)
        {
            this.Name = name;
            this.Difficulty = difficulty;       
        }
    }
}
