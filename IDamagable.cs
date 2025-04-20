using DungeonExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// This is the interface used by the player and monsters when they battle each other
    /// </summary>
    interface IDamagable
    {
        void Attack(ref Creature opponent);
        void Death(Creature opponent);
    }
}
