using DungeonExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
        /// <summary>
        /// This is an abstract class   
        ///  It will be inherited by classes for types of item:
        /// - Weapon
        /// - Potion
        /// They will contain the common properties:
        /// - Name (The name of the item)
        /// - Quality (The quality determins when a player can find an item, in accordance with the difficulty of the enemies they will earn the items from)
        /// </summary>
        public abstract class Item
        {
            public string Name { get; }
            public int Quality { get; }

            public Item(string name, int quality)
            {
                this.Name = name;
                this.Quality = quality;
            }
        }
}
