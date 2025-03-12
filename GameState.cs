using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DE_Testing_Project
{
    /// <summary>
    /// the "gamestate" will be responsible for the remainder of the game and the chance of enemies appearing once they are implemented
    /// </summary>
    public class GameState
    {
        /// <summary>
        /// The remaining number of rooms the player needs to progress through
        /// </summary>
        public int RemainingRooms { get; set; }

        /// <summary>
        /// The "Difficulty" will modify the chance of enemies appearing when the player enters a new room, currently unused as enemies have not been implemented
        /// </summary>
        public int Difficulty { get; set; }

        public GameState(int RemainingRooms, int Difficulty)
        {
            this.RemainingRooms = RemainingRooms;
            this.Difficulty = Difficulty;
        }
    }
}
