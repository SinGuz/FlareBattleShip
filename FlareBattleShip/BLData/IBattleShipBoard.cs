using System;


namespace FlareBattleShip.BLData
{
    public interface IBattleShipBoard
    {

        /// <summary>
        /// Draw ship on the board
        /// </summary>
        /// <param name="ShipSize"></param>
        /// <returns>true if successful and false if not possible to draw a ship</returns>
        public bool DrawShip(int ShipSize);

        /// <summary>
        /// Gets the current value of the cell
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public char ReturnCurrentCellValue(int i, int j);

        /// <summary>
        /// Gets the current value of the cell
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public void SetCurrentCellValue(int i, int j, char c);

        /// <summary>
        /// Gets the size of the board
        /// </summary>
        /// <returns></returns>
        public int GetBoardSize();

    }
}
