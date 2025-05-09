﻿using DungeonExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// This is the abstract creature class
    /// Its properties will be inhertited by the player and monster classes
    /// </summary>
    public abstract class Creature
    {
        protected string name;
        protected int health;
        public bool Alive { get; set; }

        public Creature(string name, int health)
        {
            this.name = name;
            this.health = health;
            Alive = true;
        }
    }
}
