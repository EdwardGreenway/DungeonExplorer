using DungeonExplorer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// This class stores the 
    /// </summary>
    public class MonsterCatalogue
    {
        /// <summary>
        /// 
        /// </summary>

        public static Monster[] Difficuly_1_Monsters { get; }
        public static Monster[] Difficuly_2_Monsters { get; }
        public static Monster[] Difficulty_3_Monsters { get; }
        public static Monster[][] DiffArrays { get; }

        static MonsterCatalogue()
        {
            /// <summary>
            /// 
            /// </summary>

            List<Monster> monsters = new List<Monster>();

            //Monster : Name, Health, Difficulty, Damage, Speed
            monsters.Add(new Monster("Rat",             2,  1,  2,  4));
            monsters.Add(new Monster("Goblin",          4,  1,  3,  5));
            monsters.Add(new Monster("Skeleton",        3,  1,  5,  3));
            monsters.Add(new Monster("Slime",           2,  2,  9,  4));
            monsters.Add(new Monster("Spider",          4,  2,  6,  8));
            monsters.Add(new Monster("Imp",             8,  2,  9,  6));
            monsters.Add(new Monster("Golem",           15, 2,  13, 2));
            monsters.Add(new Monster("Giant Slime",     18, 3,  17, 2));
            monsters.Add(new Monster("Wraith",          14, 3,  21, 4));
            monsters.Add(new Monster("Skeleton Mass",   30, 3,  24, 1));

            var D1 = monsters.Where(x => x.Difficulty == 1);
            Difficuly_1_Monsters = D1.ToArray();

            var D2 = monsters.Where(x => x.Difficulty == 2);
            Difficuly_2_Monsters = D2.ToArray();

            var D3 = monsters.Where(x => x.Difficulty == 3);
            Difficulty_3_Monsters = D3.ToArray();

            DiffArrays = new Monster[3][];
            DiffArrays[0] = Difficuly_1_Monsters;
            DiffArrays[1] = Difficuly_2_Monsters;
            DiffArrays[2] = Difficulty_3_Monsters;
        }
    }
}
