using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlareBattleShip.BLData;

namespace FlareBattleShipTester
{
    [TestClass]
    public class BattleShipBoardTester
    {
        [TestMethod]
        public void DrawShipWithLargeSize_ShouldFail()
        {
            // Arrange
            BattleShipBoard bsb_empty = new BattleShipBoard(10);

            //Act
            try
            {
                bsb_empty.DrawShip(11);

                // If it gets to this line, no exception was thrown, therefore fail
                Assert.Fail();
            }
            catch (System.ArgumentException)
            {
            }
        }


        [TestMethod]
        public void DrawShipOnAlmostFullBoard_ShouldPass()
        {
            // Arrange
            TestData td = new TestData();
            BattleShipBoard bsb_almostfull = new BattleShipBoard(td.almostAllShips);

            //Act
            bool ds = bsb_almostfull.DrawShip(3);

            //Assert
            Assert.AreEqual(true, ds);
        }

        [TestMethod]
        public void DrawShipOnFullBoard_ShouldFail()
        {
            // Arrange
            TestData td = new TestData();
            BattleShipBoard bsb_full = new BattleShipBoard(td.allShips);

            //Act
            bool ds = bsb_full.DrawShip(1);

            //Assert
            Assert.AreEqual(false, ds);
        }
    }
}
