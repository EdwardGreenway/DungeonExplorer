using MapTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DungeonExplorer
{
    internal class Game
    {
        public static bool Playing { get; set; }
        public static Player Player {  get; set; }
        public static Inventory Inventory { get; set; }                          
        public static GameMap Map { get; set; }
        static Game()
        {
            Playing = true;

            //Player (Name, Health, Health Limit, Inventory
            Player = new Player("", 40, 100, null);

            //Inventory (WeaponInvSize, PotionInvSize, Player
            Inventory = new Inventory(3, 5, Player);
            Player.Inventory = Inventory;

            //GameMap (MapSizeY, MapSizeX)
            Map = new GameMap(6,6, Player, Inventory);

            Player.GetName();
        }
        public static void Start()
        {
            while (Playing == true && Player.Alive == true)
            {
                NextMove();
            }
        }

        public static void NextMove() 
        {
            Map.EnterRoom();

            bool choosing = true;
            while (choosing == true)
            {
                Console.WriteLine("Which action will you take next?\n- Move Rooms\n- Open Inventory\n- Check Status\n");

                string choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "move rooms":
                        choosing = false;
                        Map.CheckExits();
                        break;

                    case "open inventory":
                        choosing = false;
                        Inventory.EngageInventory();
                        break;

                    case "check status":
                        choosing = false;
                        Player.ShowPlayerStatus();
                        break;

                    default:
                        Console.WriteLine("Invalid input, try again...\n");
                        break;
                }
            }
        }
    }
}
