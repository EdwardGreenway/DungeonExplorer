using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DE_Testing_Project
{
    /// <summary>
    /// the class for creating enemy objects, currently doesn't have a purpose as enemies have not been implemented into the main game loop
    /// </summary>
    internal class Enemy
    {
        /// <summary>
        /// the damage value that the enemies will deal, this value will be taken from the player's health if they are hit
        /// </summary>
        private int Damage { get; }

        /// <summary>
        /// the health value of the enemy object, the "damage" value of the weapon the player is using will be taken away from this when they attack the enemy
        /// </summary>
        private int Health { get; set; }

        /// <summary>
        /// the difficulty will determine when the enemy type can appear in the game, cooinciding with the difficulty of the "GameState" object
        /// </summary>
        private int Difficulty { get; }

        /// <summary>
        /// the name of the enemy
        /// </summary>
        private string Name { get; }

        public Enemy(int damage, int health, int difficulty, string name)
        {
            this.Damage = damage;
            this.Health = health;
            this.Difficulty = difficulty;
            this.Name = name;
        }

        public static List<Enemy> EnemyList { get; } = new List<Enemy>();

        /// <summary>
        /// creates enemy objects and stores them to a list
        /// </summary>
        public static void MakeEnemies()
        {
            EnemyList.Add(new Enemy(1, 3, 1, "Goblin"));
            EnemyList.Add(new Enemy(2, 2, 1, "Skeleton"));
            EnemyList.Add(new Enemy(1, 5, 3, "Small Slime"));
            EnemyList.Add(new Enemy(3, 3, 3, "Spider"));
            EnemyList.Add(new Enemy(4, 1, 5, "Mimic Chest"));
            EnemyList.Add(new Enemy(3, 5, 5, "Imp"));
            EnemyList.Add(new Enemy(3, 8, 6, "Stone Golem"));
            EnemyList.Add(new Enemy(5, 6, 7, "Necromancer"));
            EnemyList.Add(new Enemy(6, 7, 8, "Wraith"));
            EnemyList.Add(new Enemy(4, 15, 9, "Giant Slime"));
            EnemyList.Add(new Enemy(7, 13, 10, "Skeleton Mass"));
        }
    }
}
