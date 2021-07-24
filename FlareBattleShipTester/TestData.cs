using System;


namespace FlareBattleShipTester
{
    public class TestData
    {
        public char[,] twoShips = new char[10, 10];
        public char[,] allShips = new char[10, 10];
        public char[,] almostAllShips = new char[10, 10];

        public TestData()
        {
            //set up test data

            //twoShips
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    twoShips[i, j] = '=';
            twoShips[3, 8] = 's';
            twoShips[3, 9] = 's';
            twoShips[7, 4] = 's';
            twoShips[8, 4] = 's';

            //All ships on board
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    allShips[i, j] = 's';

            //Almost all ships on board
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    almostAllShips[i, j] = 's';
            for (int i = 7; i < 10; i++)
                for (int j = 4; j < 7; j++)
                    almostAllShips[i, j] = '=';
        }
    }
}
