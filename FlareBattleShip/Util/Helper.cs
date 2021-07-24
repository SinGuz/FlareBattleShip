using System;


namespace FlareBattleShip.Util
{
    public static class Helper
    {
        /// <summary>
        /// Gets random number in a range - inclusive
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static int GetRandom(int start, int end)
        {
            if (end <= start)
                throw new ArgumentException ("GetRandom: first argument has to be less than second argument");
            Random rnd = new Random();
            return rnd.Next(start, end);
        }

        /// <summary>
        /// forms the key of the cell based on the position
        /// NOT REQUIRED now - leave if we ever want to go dictionary way
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static string FormKey(int start, int end)
        {
            return (String.Format("{0:D4}-{1:D4}", start, end));
        }

        /// <summary>
        /// Gets the character associated with the cell enum
        /// </summary>
        /// <param name="ecs"></param>
        /// <returns></returns>
        public static char GetCharFromCellEnum(Enums.CellState ecs)
        {
            switch (ecs)
            {
                case Enums.CellState.Empty:
                    return '=';
                case Enums.CellState.Ship:
                    return 's';
                case Enums.CellState.Hit:
                    return 'h';
                case Enums.CellState.Sunk:
                    return 'k';
                case Enums.CellState.Miss:
                    return 'm';
                default:
                    throw new ArgumentException("GetCharFromCellEnum: invalid cell state");
            }
        }

        /// <summary>
        /// Gets CellState enum based on the character
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Enums.CellState GetCellEnumFromChar(char c)
        {
            switch (c)
            {
                case '=':
                    return Enums.CellState.Empty;
                case 's':
                    return Enums.CellState.Ship;
                case 'h':
                    return Enums.CellState.Hit;
                case 'k':
                    return Enums.CellState.Sunk;
                case 'm':
                    return Enums.CellState.Miss;
                default:
                    throw new ArgumentException("GetCellEnumFromChar: invalid character passed in");
            }
        }

        /// <summary>
        /// Gets the attack result string to display 
        /// </summary>
        /// <param name="ar"></param>
        /// <returns></returns>
        public static string GetStringFromAttackEnum(Enums.AttackResult ar)
        {
            switch (ar)
            {
                case Enums.AttackResult.Miss:
                    return "Miss";
                case Enums.AttackResult.Hit:
                    return "Hit";
                case Enums.AttackResult.AllSunk:
                    return "All Sunk - Surrender - you win!";
                default:
                    throw new ArgumentException("GetStringFromAttackEnum: invalid cell state");
            }
        }
    }
}
