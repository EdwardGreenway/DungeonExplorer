using DE_Testing_Project;
using System;
using System.Media;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace Dungeon_Explorer
{
    /// <summary>
    /// Represents the game logic and flow of the game
    /// </summary>
    internal class Game
    {
        /// <summary>
        /// The player character in the game
        /// </summary>
        Player player;

        /// <summary>
        /// The current room the player is in
        /// </summary>
        Room currentRoom;

        /// <summary>
        /// The current game state.
        /// </summary>
        GameState newGame;

        /// <summary>
        /// Starts the game loop & initialises various game objects 
        /// </summary>
        public void Start()
        {
            Console.WriteLine("Welcome to dungeon explorer!\nIn this game you will progress through the dungeon rooms, fight enemies, find items and find the exit.");

            InitialiseGameObjects();

            bool playing = true;
            while (playing == true)
            {
                if (newGame.RemainingRooms > 0)
                {
                    bool choosing = true;
                    while (choosing == true)
                    {
                        Console.WriteLine("What action would you like to take next?\n");
                        Console.WriteLine("- Move forward [Forward]\n- Check your status [Status]\n- Check inventory[Inventory]\n- Quit game[Quit]\n");
                        string input = Console.ReadLine();
                        string inputLower = input.ToLower();

                        switch (inputLower)
                        {
                            case "forward":
                                Console.WriteLine("You move forward through the dungeon...\n");
                                choosing = false;
                                break;

                            case "status":
                                Console.WriteLine("You check your status.");
                                player.ShowPlayerStatus();
                                choosing = false;
                                break;

                            case "inventory":
                                Console.WriteLine("You check your inventory.");
                                player.ShowInventory();
                                choosing = false;
                                break;

                            case "quit":
                                Console.WriteLine("Thanks for playing, goodbye!");
                                choosing = false;
                                playing = false;
                                break;

                            default:
                                Console.WriteLine("Invalid command. Try again.");
                                break;
                        }
                    }
                }
                else if (player.PlayerHealth <= 0)
                {
                    Console.WriteLine(player.PlayerName + " has been slain in the dungeon...\n[GAME OVER]");
                    playing = false;
                }
                else
                {
                    Console.WriteLine(player.PlayerName + " has escaped the dungeon!\nYOU'RE WINNER!");
                    playing = false;
                }
            }
        }

        /// <summary>
        /// Initializes the game objects including the player, rooms, and enemy objects
        /// </summary>
        public void InitialiseGameObjects()
        {
            newGame = new GameState(5, 1);
            Item rustyDagger = new Item(2, 0, "Rusty Dagger"); //this is the initial item the player will have when they start the game, more will be added later, accesses from the "Item" class
            player = new Player("", 20, rustyDagger);
            Item.MakeItems();
            Player.GetPlayerName(player);
            Room.MakeRooms();
            Enemy.MakeEnemies();
        }
    }
}
