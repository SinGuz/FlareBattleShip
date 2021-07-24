using System;
using FlareBattleShip.Util;


namespace FlareBattleShip.BLData
{
    public class BattleShipStateManager
    {
        //board that state manager will work with
        private IBattleShipBoard bsb;

        //number of ship cells on the board
        //we could make a corresponding public property if we need to exxpose how many ship cells are left 
        private int totalNumberShipCells = 0;

        /// <summary>
        /// main constructor - valid board needs to be passed in
        /// </summary>
        /// <param name="importedBoard"></param>
        public BattleShipStateManager(IBattleShipBoard importedBoard)
        {
            this.bsb = importedBoard;

            //set the values of the ship cells
            SetInitialNumberOfShipCells();
        }

        /// <summary>
        /// Counts the number of ship cells on the board
        /// </summary>
        private void SetInitialNumberOfShipCells()
        {
            // get the size of the board
            int ms = bsb.GetBoardSize();

            for (int i = 0; i < ms; i++)
                for (int j = 0; j < ms; j++)
                    if (bsb.ReturnCurrentCellValue(i, j) == Helper.GetCharFromCellEnum(Enums.CellState.Ship))
                        totalNumberShipCells ++;

            //verify that at least one ship is present on the board;
            if (totalNumberShipCells == 0)
                throw new ArgumentException("BattleShipStateManager: Invalid board, no ships present");
        }

        /// <summary>
        /// Main method - it will check whether an attack is a hit, miss or AllSunk (surrender)
        /// </summary>
        /// <param name="attack_i"></param>
        /// <param name="attack_j"></param>
        /// <returns></returns>
        public Enums.AttackResult ReceiveAttack(int attack_i, int attack_j)
        {
            // get the size of the board
            int ms = bsb.GetBoardSize();
            // check that the ShipSize is not larger than matrix sise
            if (attack_i > ms || attack_j > ms)
                throw new ArgumentException("ReceiveAttack: passed in value greater than board!");

            //get the value of the attacked cell
            char attackcell = bsb.ReturnCurrentCellValue(attack_i, attack_j);

            Enums.CellState ecs = Helper.GetCellEnumFromChar(attackcell);
            switch (ecs)
            {
                case Enums.CellState.Ship:
                    //mark the cell as hit
                    bsb.SetCurrentCellValue(attack_i, attack_j, Helper.GetCharFromCellEnum(Enums.CellState.Hit));
                    //set the value of the key to zero 
                    totalNumberShipCells --;
                    //if there are no more ships, return all sunk, otherwise hit
                    if (totalNumberShipCells == 0)
                        return (Enums.AttackResult.AllSunk);
                    else
                        return (Enums.AttackResult.Hit);

                case Enums.CellState.Empty:
                    //set the value to miss to keep track of what they attacked (if we ever want to print the state
                    bsb.SetCurrentCellValue(attack_i, attack_j, Helper.GetCharFromCellEnum(Enums.CellState.Miss));
                    return (Enums.AttackResult.Miss);
                default:
                    //return miss in all other cases - we are not going to be nice and tell them that the cell is already hit or miss
                    return (Enums.AttackResult.Miss);
            }
        }
    }
}
