using System;
using System.Collections.Generic;

namespace Dungeon_Explorer
{
    /// <summary>
    /// Player class is responsible for everything player related in the game
    /// 
    /// - Name
    /// - Health 
    /// - Items
    /// </summary>
    public class Player
    {
        Player player;

        private string playerName;
        private int playerHealth;
        Item equippedItem;
        List<Item> inventoryItems = new List<Item>();

        public Player(string playerName, int playerHealth, Item equippedItem)
        {
            this.PlayerName = playerName;
            this.PlayerHealth = playerHealth;
            this.equippedItem = equippedItem;
        }

        /// <summary>
        /// This property is responsible for handling the player's name
        /// It also verifies if the name being offered is valid
        /// </summary>
        public string PlayerName
        {
            get { return playerName; }
            set
            {

                bool isChoosing = true;

                while (isChoosing == true)
                {
                    if (value.Length > 12)
                    {
                        Console.WriteLine("That name is too long, 12 characters maximum...\n-\n-\n-");
                        Console.WriteLine("Enter your name below\nPress [ENTER] when finished\n");
                        value = Console.ReadLine();
                    }
                    else
                    {
                        playerName = value;
                        isChoosing = false; ;
                    }
                }
            }
        }

        /// <summary>
        /// Player health doesn't currently have a practical purpose, it should recieve more development once enemies are implemented into the game
        /// </summary>
        public int PlayerHealth
        {
            get { return playerHealth; }
            set
            {
                playerHealth = value;
            }
        }

        /// <summary>
        /// This method assigns the player's name
        /// Used at the start of the game
        /// </summary>
        public static void GetPlayerName(Player player)
        {
            Console.WriteLine("First of all, what is your name?\nPress [ENTER] when finished");

            player.PlayerName = Console.ReadLine();

            Console.WriteLine("Your journey starts here, " + player.PlayerName + ".");
        }

        /// <summary>
        /// This is the method for picking up items (objects)
        /// It's not currently used in the actual game, will be developed further once the rooms are expanded upon with random enemies/items
        /// </summary>
        public void PickUpItem(Item item)
        {
            inventoryItems.Add(item);
            Console.WriteLine("You picked up the " + item.Name + ".");
        }

        /// <summary>
        /// The method for equipping items is currently blank
        /// Currently the only item available to the player is assigned to the player object when it is created
        /// This method will be developed to a funcitonal level once the game is expanded further
        /// </summary>
        public void EquipItem(string itemName)
        {

        }

        /// <summary>
        /// This method doesn't have a purpose currently, will have more of a purpose once items are developed further
        /// </summary>
        public void ShowInventory()
        {
            if (inventoryItems.Count == 0)
            {
                Console.WriteLine("_________________________________________________");
                Console.WriteLine("Your inventory is empty.");
                Console.WriteLine("_________________________________________________");
            }
            else
            {
                Console.WriteLine("Your inventory contains:");
                foreach (var item in inventoryItems)
                {
                    Console.WriteLine(item.Name);
                }
                Console.WriteLine("_________________________________________________");
            }
        }

        public void ShowPlayerStatus()
        {
            Console.WriteLine("_________________________________________________");

            Console.WriteLine(playerName + "'s current status:");
            Console.WriteLine("Health: " + playerHealth);
            Console.WriteLine("Equipped Weapon: " + equippedItem.Name);
            Console.WriteLine("It deals " + equippedItem.Damage + " damage per hit");

            Console.WriteLine("_________________________________________________");
        }
    }
}