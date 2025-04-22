using DungeonExplorer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// This class generates items and sorts them into an array
    /// The array will be used to decide which items enemies can drop for a player when they are defeated
    /// </summary>
    public class ItemCatalogue
    {
        public static Item[] Quality_0_Items { get; }
        public static Item[] Quality_1_Items { get; }
        public static Item[] Quality_2_Items { get; }
        public static Item[] Quality_3_Items { get; }
        public static Item[][] QArrays { get; } 

        static ItemCatalogue()
        {

            //Weapon: Name, Quality, Damage, Speed
            List<Item> items = new List<Item>();

            items.Add(new Weapon("[EMPTY]",                 0, 0, 0));
            items.Add(new Weapon("Rusty Dagger",            0, 2, 4));

            items.Add(new Weapon("Iron Knife",              1, 3, 5));
            items.Add(new Weapon("Wooden Club",             1, 5, 3));
            items.Add(new Weapon("Short Sword",             2, 6, 5));
            items.Add(new Weapon("Steel Broadsword",        2, 8, 3));
            items.Add(new Weapon("Diamond Spear",           3, 11, 4));
            items.Add(new Weapon("Battle Mace",             3, 17, 1));

            //Potion: Name, Quality, Health healed
            items.Add(new Potion("[EMPTY]",                 0, 0));
            items.Add(new Potion("Tiny Health Potion",      0, 3));
            items.Add(new Potion("Small Health Potion",     1, 6));
            items.Add(new Potion("Medium Health Potion",    2, 9));
            items.Add(new Potion("Large Health Potion",     3, 14));

            var Q0 = items.Where(x => x.Quality == 0);
            Quality_0_Items = Q0.ToArray();

            var Q1 = items.Where(x => x.Quality == 1);
            Quality_1_Items = Q1.ToArray();

            var Q2 = items.Where(x => x.Quality == 2);
            Quality_2_Items = Q2.ToArray();

            var Q3 = items.Where(x => x.Quality == 3);
            Quality_3_Items = Q3.ToArray();

            QArrays = new Item[3][];
            QArrays[0] = Quality_1_Items;
            QArrays[1] = Quality_2_Items;
            QArrays[2] = Quality_3_Items;
        }
    }
}
