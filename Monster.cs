using DungeonExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// This is the monster class
    /// It is a derivative of the creature class, containing its own unique properties and methods for fighting the player
    /// </summary>
    public class Monster : Creature, IDamagable
    {
        public string Name { get; }
        public int Health
        {
            get { return health; }
            set
            {
                if (value <= 0)
                {
                    Alive = false;
                }
                else
                {
                    health = value;
                }
            }
        }

        public int Difficulty { get; }
        public int Damage { get; }
        public int Speed { get; }
        public Item ItemDrop { get; }

        public Monster(string name, int health, int difficulty, int damage, int speed) : base(name, health)
        {
            this.Name = name;
            this.Health = health;
            this.Difficulty = difficulty;
            this.Damage = damage;
            this.Speed = speed;

            Random random = new Random();
            Item[] itemPool = ItemCatalogue.QArrays[Difficulty - 1];

            //picks a random item from the chosen array
            int randomItem = random.Next(0, itemPool.Length);
            ItemDrop = itemPool[randomItem];
        }

        public void Attack(ref Creature opponent)
        {
            Player playerOpponent = opponent as Player;

            playerOpponent.Health -= Damage;
            Console.WriteLine(Name + " strikes " + playerOpponent.Name + " for " + Damage + " damage.");
            Console.WriteLine(playerOpponent.Name + " now has " + playerOpponent.Health + " health.\n");
        }
        public void Death(Creature opponent)
        {
            Player player = opponent as Player;
            Console.WriteLine(player.Name + " has slain the " + Name);
            Console.WriteLine("The " + Name + " dropped the " + ItemDrop.Name);
        }
    }
}