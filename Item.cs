using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Explorer
{
    /// <summary>
    /// Class for items, currently unused due to enemies and fighting not yet being in the game
    /// </summary>
    public class Item
    {
        /// <summary>
        /// damage refers to the amount that the weapon will take away from the health of the enemy when they are implemented
        /// </summary>
        public int Damage { get; }

        /// <summary>
        /// items will be given a "difficulty" value, something that will determine the point of the game that they can be found by the players
        /// </summary>
        public int Difficulty { get; }

        /// <summary>
        /// The name of the item, what it is called in the game
        /// </summary>
        public string Name { get; }

        public Item(int damage, int difficulty, string name)
        {
            this.Damage = damage;
            this.Difficulty = difficulty;
            this.Name = name;
        }

        public static List<Item> ItemList { get; } = new List<Item>();

        /// <summary>
        /// function that creates several item objects and stores then in a list
        /// </summary>
        public static void MakeItems()
        {
            ItemList.Add(new Item(2, 0, "Rusty Dagger"));
            ItemList.Add(new Item(3, 1, "Wooden Club"));
            ItemList.Add(new Item(4, 3, "Short Sword"));
            ItemList.Add(new Item(5, 4, "Iron Axe"));
            ItemList.Add(new Item(7, 6, "Steel Broadsword"));
            ItemList.Add(new Item(9, 7, "Battle Mace"));
        }
    }
}
