using DungeonExplorer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace DungeonExplorer
{
    /// <summary>
    /// Player class is responsible for a player's characteristics                  
    /// It works in conjunction with the inventory class, which handles their items
    /// The most important part of this class is the properties:
    /// - Name
    /// - Health
    /// </summary>
    public class Player : Creature, IDamagable
    {                                                                                                 
        public string Name
        {                                                                                                                                                                                                
            get { return name; }
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
                        name = value;
                        isChoosing = false; ;
                    }
                }
            }
        }
        public int Health
        {
            get { return health; }
            set
            {
                if (value >= HealthLimit)
                {
                    Console.WriteLine("Health limit reached...");
                    health = HealthLimit;
                }
                else if (value <= 0)
                {
                    Alive = false;
                }
                else
                {
                    health = value;
                }
            }
        }
        public int HealthLimit { get; }
        public Inventory Inventory { get; set; }
        public Player(string name, int health, int healthLimit, Inventory inventory) : base(name, health)
        {
            this.Name = name;
            this.HealthLimit = healthLimit;
            this.Health = health;
            this.Inventory = inventory;
        }

        public void GetName()
        {
            Console.WriteLine("First of all, what is your name?\nPress [ENTER] when finished");

            Name = Console.ReadLine();

            Console.WriteLine("Your journey starts here, " + Name +".\n");
        }
                                                                    
        public void ShowPlayerStatus()
        {
            Console.WriteLine("_________________________________________________");

            Console.WriteLine(Name + "'s current status:");
            Console.WriteLine("Health: " + Health);

            Console.WriteLine("_________________________________________________");
        }

        public void Battle(Creature opponent)
        {
            Monster monster = opponent as Monster;

            Console.WriteLine("The " + monster.Name + " stands before you...\n");
            Console.WriteLine("- Fight\n" +
                "- Potion\n" +
                "- Examine\n");


            bool turn = true;
            while (turn == true)
            {
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "fight":
                        turn = false;
                        Attack(ref opponent);
                        break;

                    case "potion":
                        turn = false;
                        Inventory.DrinkPotion();
                        Battle(opponent);
                        break;

                    case "examine":
                        Console.WriteLine("Name: " + monster.Name);
                        Console.WriteLine("Health: " + monster.Health);
                        Console.WriteLine("Damage: " + monster.Damage);
                        Console.WriteLine("Speed: " + monster.Speed);
                        Console.WriteLine("Item Drop: " + monster.ItemDrop.Name + "\n");
                        Battle(opponent);
                        break;

                    default:
                        Console.WriteLine("Invalid input, try again.\n");
                        break;
                }
            }
        }

        public void Attack(ref Creature opponent)
        {
            Monster monsterOpponent = opponent as Monster;

            monsterOpponent.Health -= Inventory.EquippedWeapon.Damage;

            Console.WriteLine(Name + " strikes " + monsterOpponent.Name + " for " + Inventory.EquippedWeapon.Damage + " damage.");
            Console.WriteLine("The " + monsterOpponent.Name + " now has " + monsterOpponent.Health + " health.\n");
        }

        public void Death(Creature opponent)
        {
            Monster monster = opponent as Monster;
            Console.WriteLine(Name + " was slain by " + monster.Name);
            Console.WriteLine("[[[ GAME OVER ]]]");
        }
    }
}