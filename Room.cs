using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Policy;

namespace Dungeon_Explorer
{
    /// <summary>
    /// Class that handles room creation
    /// </summary>
    public class Room
    {
        /// <summary>
        /// the description of the room the player has entered
        /// </summary>
        private string Description { get; }

        /// <summary>
        /// the number of the room the player has entered, this will not be shown to the user
        /// </summary>
        private int Id { get; }

        public Room(int id, string description)
        {
            this.Id = id;
            this.Description = description;
        }

        public static List<Room> RoomList { get; } = new List<Room>();

        /// <summary>
        /// this method makes rooms and stores them in a list
        /// </summary>
        public static void MakeRooms()
        {
            RoomList.Add(new Room(1, "You enter a hallway built of cobbled stone.Torches adorn the walls, dimly lighting your path."));
            RoomList.Add(new Room(2, "You emerge into a library, visibly forgotten and aged. Worn books allign the seemingly endless dust covered shelves, extending far beyond the darkness that comprises your path forward."));
            RoomList.Add(new Room(3, "A strange area, you crawl through the tunnel into a damp and cold cavern. Water drips from the jagged ends of pointed rocks, every sound echoing through the expanse of the cave."));
            RoomList.Add(new Room(4, "Before you stands a white marbled altar, soiled with the stains of dried blood. Strange unreadable symbols run along the edges of your continuing path."));
            RoomList.Add(new Room(5, "The sounds of rats and dangling chains are all that remains in this abandoned prison, even the remains of the unfortunate people that were held here seem to have been lost to the sands of time."));
            RoomList.Add(new Room(6, "Flora has engulfed this once tamed garden. Vines and glowing mushrooms have claimed what was once their prison, englufling much of the walls and ceiling, with such sights obscuring your path."));
        }
    }
}