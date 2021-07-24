using System;

using FlareBattleShip.Util;

namespace FlareBattleShip.BLData
{

    public class BattleShipBoard : IBattleShipBoard
    {
        //main board two dimensional array
        private char[,] bs_matrix;

        /// <summary>
        /// Constructor that will create a board and populate it with empty spaces
        /// </summary>
        /// <param name="ms"></param>
        public BattleShipBoard(int ms)
        {
            // get the size of the aatrix
            // decided not to grab it from config but as a parameter to a constructor
            //int ms = Config.Cnfg.MatrixSize;

            //get the empty character string
            char empty = Helper.GetCharFromCellEnum(Enums.CellState.Empty);

            //create
            bs_matrix = new char[ms, ms];

            //populate the whole entry with empty spaces
            for (int i = 0; i < ms; i++)
                for (int j = 0; j < ms; j++)
                    bs_matrix[i, j] = empty;
        }

        /// <summary>
        /// Constructor that will take already filled in board
        /// probably does not make much sense for the game but it will come in
        /// handy to test State Manager
        /// make this environment specific?
        /// </summary>
        /// <param name="PopulatedBoard"></param>
        public BattleShipBoard(char[,] PopulatedBoard)
        {
            //just do some simple validation - assume that the board is correct
            //if it was a real project, you would verify that it is correctly 
            //populated with valid chracters and some other logic
            //i.e. that there are ships(not all sunk or not all only empty, hit and miss )
            //it can take some time to go through combinations

            int iSize = PopulatedBoard.GetLength(0);
            int jSize = PopulatedBoard.GetLength(1);

            if(iSize == 0 || jSize == 0 || iSize != jSize)
                throw new ArgumentException("BattleShipBoardBoard: Invalid dimensions of the board");

            bs_matrix = PopulatedBoard;
        }

        /// <summary>
        /// Draw ship on the board
        /// </summary>
        /// <param name="ShipSize"></param>
        /// <returns>true if successful and false if not possible to draw a ship</returns>
        public bool DrawShip(int ShipSize)
        {
            int loopCounter = 0;
            // get the size of the board
            int ms = bs_matrix.GetLength(0);
            // check that the ShipSize is not larger than matrix sise
            if (ShipSize > ms)
                throw new ArgumentException("DrawShip: Size of Ship greater than board!");

            //get into some sort of loop to try to find out possible position for the ship
            //if this was real we would need some smartness to figure out whether drawing a ship is possibe;
            while (loopCounter < 10000)
            {
                loopCounter++;

                //get random starting location
                int start_i = Helper.GetRandom(0, ms - 1);
                int start_j = Helper.GetRandom(0, ms - 1);

                Tuple<int, int> endLoc = FindEndPoint(start_i, start_j, ShipSize);

                //if this point is not possible try next point
                if (endLoc.Item1 == -1)
                    continue;

                char Ship = Helper.GetCharFromCellEnum(Enums.CellState.Ship);
                //mark the ship on the board
                for (int i = Math.Min(start_i, endLoc.Item1); i <= Math.Max(start_i, endLoc.Item1); i++)
                    for (int j = Math.Min(start_j, endLoc.Item2); j <= Math.Max(start_j, endLoc.Item2); j++)
                        bs_matrix[i, j] = Ship;


                return true;
            }

            return false;
        }

        /// <summary>
        /// Find the end point and return it as a pair of int values
        /// </summary>
        /// <param name="start_i"></param>
        /// <param name="start_j"></param>
        /// <param name="ShipSize"></param>
        /// <returns>a pair of negative values if end point can not be found</returns>
        private Tuple<int, int> FindEndPoint(int start_i, int start_j, int ShipSize)
        {
            // get the size of the board
            int ms = bs_matrix.GetLength(0);

            //need to think if this is really random but good enough for now
            Enums.Direction rndDirection = (Enums.Direction)Helper.GetRandom(0, 3);

            switch (rndDirection)
            {
                case Enums.Direction.Down:
                    //try vertical - down location
                    if (start_i + ShipSize - 1 < ms && CheckAllEmpty(start_i, start_j, start_i + ShipSize - 1, start_j))
                    {
                        return Tuple.Create(start_i + ShipSize - 1, start_j);
                    }
                    break;
                case Enums.Direction.Up:
                    //try vertical - up location
                    if (start_i - ShipSize + 1 >= 0 && CheckAllEmpty(start_i, start_j, start_i - ShipSize + 1, start_j))
                    {
                        return Tuple.Create(start_i - ShipSize + 1, start_j);
                    }
                    break;
                case Enums.Direction.Right:
                    //try horizontal - right  location
                    if (start_j + ShipSize - 1 < ms && CheckAllEmpty(start_i, start_j, start_i, start_j + ShipSize - 1))
                    {
                        return Tuple.Create(start_i, start_j + ShipSize - 1);
                    }
                    break;
                case Enums.Direction.Left:
                    //try horizontal - left  location
                    if (start_j - ShipSize + 1 >= 0 && CheckAllEmpty(start_i, start_j, start_i, start_j - ShipSize + 1))
                    {
                        return Tuple.Create(start_i, start_j - ShipSize + 1);
                    }
                    break;
            }

            //not able to find end point in this iteration
            return Tuple.Create(-1, -1);
        }

        /// <summary>
        /// check that all spaces in the range are empty
        /// </summary>
        /// <param name="start_i"></param>
        /// <param name="start_j"></param>
        /// <param name="end_i"></param>
        /// <param name="end_j"></param>
        /// <returns>true is all empty, false if at least one is not marked as empty</returns>
        private bool CheckAllEmpty(int start_i, int start_j, int end_i, int end_j)
        {
            //get the empty character string
            char empty = Helper.GetCharFromCellEnum(Enums.CellState.Empty);

            //if any of the cells is not marked as empty return false
            for (int i = Math.Min(start_i, end_i); i <= Math.Max(start_i, end_i); i++)
                for (int j = Math.Min(start_j, end_j); j <= Math.Max(start_j, end_j); j++)
                    if (bs_matrix[i, j] != empty)
                        return false;

            //otherwise return false
            return true;
        }

        /// <summary>
        /// publicly available board array
        /// Not sure it is required for this project but it can be useful if we want to print values etc
        /// </summary>
        public char[,] BS_Matrix
        {
            get { return bs_matrix; }
            //only allow setting of the board through the constructor
            //set { //bs_matrix = BS_Matrix; }
        }

        /// <summary>
        /// Gets the current value of the cell
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public char ReturnCurrentCellValue(int i, int j)
        {
            // get the size of the board
            int ms = bs_matrix.GetLength(0);
            // check that the ShipSize is not larger than matrix sise
            if (i > ms || j > ms)
                throw new ArgumentException("ReturnCurrentCellValue: passed in value greater than board!");

            return bs_matrix[i, j];
        }

        /// <summary>
        /// Sets the current value of the cell
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public void SetCurrentCellValue(int i, int j, char c)
        {
            // get the size of the board
            int ms = bs_matrix.GetLength(0);
            // check that the ShipSize is not larger than matrix sise
            if (i > ms || j > ms)
                throw new ArgumentException("SetCurrentCellValue: passed in value greater than board!");

            bs_matrix[i, j] = c;
        }

        /// <summary>
        /// Gets the size of the board
        /// </summary>
        /// <returns></returns>
        public int GetBoardSize()
        {
            return bs_matrix.GetLength(0);
        }
    }
}
