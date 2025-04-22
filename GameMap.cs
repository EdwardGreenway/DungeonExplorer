using DungeonExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static DungeonExplorer.RoomCatalogue;

namespace MapTesting
{
    /// <summary>
    /// This is the GameMap class
    /// It contains the properties and methods that will be required for the player to progress through the rooms that will be generated
    /// </summary>
    internal class GameMap
    {
        public int Difficulty {  get; set; }
        public int CurRoomY { get; set; }
        public int CurRoomX { get; set; }
        public int FinalRoomY {  get; set; }
        public int FinalRoomX { get; set; }
        public int EncounterChance { get; set; }
        public Random random { get; set; }
        public Player Player { get; set; }
        public Inventory Inventory { get; set; }
        public Room[,] Map {  get; }
        public Room[,] CurrentFloor { get; set; }
        public GameMap(int x, int y, Player player, Inventory inventory)
        {
            Difficulty = 1;
            EncounterChance = 0;

            this.Player = player;
            this.Inventory = inventory;

            this.Map = new Room[y, x];

            Random random = new Random();
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for(int j = 0; j < Map.GetLength(1); j++)
                {
                    Room[] roomPool = RoomCatalogue.FloorArrays[0].ToArray();

                    int randomRoom = random.Next(0, roomPool.Length);
                    Room room = roomPool[randomRoom];

                    Map[i, j] = room;
                }
            }

            CurRoomY = 0;
            CurRoomX = (Map.GetLength(1) - 1) / 2;

            FinalRoomY = Map.GetLength(0) - 1;
            FinalRoomX = Map.GetLength(1) / 2;
        }


        /// <summary>
        /// All of the game's navigation takes place only within the "GameMap" class, therefore properties can be accessed directory without needing to be passed as parameters
        /// The "CheckSurroundings()" method will check which parts of the floor array are accessible, 
        /// </summary>
        public void EnterRoom()
        {
            Console.WriteLine("You are now in the " + Map[CurRoomY, CurRoomX].Name + ".\n");
            DifficultyCheck();

            Random random = new Random();
            int encounter = random.Next(EncounterChance, 3);

            if (encounter >= 1)
            {
                RandomEncounter(Player, Inventory);
                EncounterChance = 0;
            }
            else
            {
                EncounterChance++;
            }

            if (CurRoomY == FinalRoomY && CurRoomX == FinalRoomX)
            {
                Game.Playing = false;
                Console.WriteLine("You escaped the dungeon, well done!\n");
            }
            else
            {
                Console.WriteLine("You check your surroundings...\n");
            }
        }   

        public void CheckExits()
        {
            Console.WriteLine("Which direction will you go next?...\n");

            bool canGoForward = false;
            bool canGoBackward = false;
            bool canGoLeft = false;
            bool canGoRight = false;

            bool choosing = true;
            while (choosing == true)
            {
                Console.WriteLine("Which direction will you go next?\n");

                if (!(CurRoomY >= (Map.GetLength(0) - 1)))
                {
                    canGoForward = true;
                    Console.WriteLine("- Forward");
                }
                if (!(CurRoomY <= 0))
                {
                    canGoBackward = true;
                    Console.WriteLine("- Backward");
                }
                if (!(CurRoomX >= (Map.GetLength(0) - 1)))
                {
                    canGoLeft = true;
                    Console.WriteLine("- Left");
                }
                if (!(CurRoomX <= 0))
                {
                    canGoRight = true;
                    Console.WriteLine("- Right");
                }

                string direction = Console.ReadLine().ToLower();
                switch (direction)
                {
                    case "forward":
                        if (canGoForward == true)
                        {
                            choosing = false;
                            MoveForward();
                        }
                        else
                        {
                            Console.WriteLine("Invalid input, try again...");
                        }
                        break;
                    case "backward":
                        if (canGoBackward == true)
                        {
                            choosing = false;
                            MoveBackward();
                        }
                        else
                        {
                            Console.WriteLine("Invalid input, try again...");
                        }
                        break;
                    case "left":
                        if (canGoLeft == true)
                        {
                            choosing = false;
                            MoveLeft();
                        }
                        else
                        {
                            Console.WriteLine("Invalid input, try again...");
                        }
                        break;
                    case "right":
                        if (canGoRight == true)
                        {
                            choosing = false;
                            MoveRight();
                        }
                        else
                        {
                            Console.WriteLine("Invalid input, try again...");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid input, try again...\n");
                        break;
                }
            }

        }

        public void DifficultyCheck()
        {
            if (CurRoomY > 1)
            {
                Difficulty = 1;
            }
            else if (CurRoomY > (Map.GetLength(0) / 3) - 1)
            {
                Difficulty = 2;
            }
            else if (CurRoomX > ((Map.GetLength(0) / 3) * 2) - 1)
            {
                Difficulty = 3;
            }
        }

        public void MoveForward()
        {
            CurRoomY = CurRoomY + 1;
        }

        public void MoveBackward()
        {
            CurRoomY = CurRoomY - 1;
        }

        public void MoveLeft()
        {
            CurRoomX = CurRoomX + 1;
        }

        public void MoveRight()
        {
            CurRoomX = CurRoomX - 1;
        }

        public Monster RandomMonster()
        {
            random = new Random();
            Monster[] monsterPool = MonsterCatalogue.DiffArrays[Difficulty - 1];

            int randomMonster = random.Next(0, monsterPool.Length);
            Monster monster = monsterPool[randomMonster];

            return monster;
        }

        public void RandomEncounter(Creature player, Inventory inventory)
        {
            Monster monster = RandomMonster();
            Player playerOpponent = player as Player;
            Monster monsterOpponent = monster;

            Console.WriteLine("The " + monsterOpponent.Name + " blocks " + playerOpponent.Name + "'s path!\n");

            bool battling = true;
            while (battling == true)
            {
                if (playerOpponent.Alive == true && monsterOpponent.Alive == false)
                {
                    battling = false;
                    monsterOpponent.Death(playerOpponent);
                    inventory.CollectItem(monsterOpponent.ItemDrop);
                }
                else if (playerOpponent.Alive == false && monsterOpponent.Alive == true)
                {
                    battling = false;
                }
                else
                {
                    if (inventory.EquippedWeapon.Speed < monsterOpponent.Speed)
                    {
                        monsterOpponent.Attack(ref player);
                        playerOpponent.Battle(monsterOpponent);
                    }
                    else
                    {
                        playerOpponent.Battle(monsterOpponent);
                        monsterOpponent.Attack(ref player);
                    }
                }
            }
        }
    }
}