using DungeonExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class RoomCatalogue
    {
        /// <summary>
        /// 
        /// </summary>
        public static Room[] Difficulty_1_Rooms { get; }
        public static Room[] Difficulty_2_Rooms { get; }
        public static Room[] Difficulty_3_Rooms { get; }
        public static Room[][] FloorArrays { get; }
        static RoomCatalogue()
        {
            List<Room> rooms = new List<Room>();
            
            //Monster : Name, difficulty 
            rooms.Add(new Room("Abandoned Library",     1));
            rooms.Add(new Room("Cobblestone hallway",   1));
            rooms.Add(new Room("Decaying sewers",       1));
            rooms.Add(new Room("Overgrown garden",      2));
            rooms.Add(new Room("Rusting prison cells",  2));
            rooms.Add(new Room("Soldier barracks",      2));
            rooms.Add(new Room("Underground church",    2));
            rooms.Add(new Room("Dark cave",             3));
            rooms.Add(new Room("Howling mines",         3));
            rooms.Add(new Room("Frozen crypt",          3));

            var F1 = rooms.Where(x => x.Difficulty == 1);
            Difficulty_1_Rooms = F1.ToArray();

            var F2 = rooms.Where(x => x.Difficulty == 2);
            Difficulty_2_Rooms = F2.ToArray();

            var F3 = rooms.Where(x => x.Difficulty == 3);
            Difficulty_3_Rooms = F3.ToArray();

            FloorArrays = new Room[3][];
            FloorArrays[0] = Difficulty_1_Rooms;
            FloorArrays[1] = Difficulty_2_Rooms;
            FloorArrays[2] = Difficulty_3_Rooms;
        }
    }
}
