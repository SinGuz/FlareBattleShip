using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlareBattleShip.Util
{

    public class Enums
    {
        /// <summary>
        /// all possible states of each cell in board matrix
        /// Sunk is probably not necessary - leave it in here if we want to mark
        /// the winning move
        /// </summary>
        public enum CellState
        {
            Ship,
            Miss,
            Hit,
            Sunk,
            Empty
        }

        /// <summary>
        /// possible returns from an attack
        /// </summary>
        public enum AttackResult
        {
            Miss,
            Hit,
            AllSunk
        }

        /// <summary>
        /// dircetion in which to travel
        /// Might not be necessary ???
        /// </summary>
        public enum Direction
        {
            Down,
            Up,
            Right,
            Left
        }
    }
}
