using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlareBattleShip.BLData;
using FlareBattleShip.Util;

namespace FlareBattleShipTester
{
    [TestClass]
    public class BattleShipStateManagerTester
    {
        [TestMethod]
        public void MultipleTestsOfAttack_ShouldPass()
        {
            // Arrange
            TestData td = new TestData();
            BattleShipBoard bsb_test = new BattleShipBoard(td.twoShips);
            BattleShipStateManager bssm = new BattleShipStateManager(bsb_test);

            //Act

            //Assert
            Assert.AreEqual(bssm.ReceiveAttack(1, 2), Enums.AttackResult.Miss);
            Assert.AreEqual(bssm.ReceiveAttack(3, 8), Enums.AttackResult.Hit);
            Assert.AreEqual(bssm.ReceiveAttack(1, 2), Enums.AttackResult.Miss);
            Assert.AreEqual(bssm.ReceiveAttack(3, 9), Enums.AttackResult.Hit);
            Assert.AreEqual(bssm.ReceiveAttack(3, 8), Enums.AttackResult.Miss);
            Assert.AreEqual(bssm.ReceiveAttack(7, 4), Enums.AttackResult.Hit);
            Assert.AreEqual(bssm.ReceiveAttack(9, 4), Enums.AttackResult.Miss);
            Assert.AreEqual(bssm.ReceiveAttack(8, 4), Enums.AttackResult.AllSunk);
        }

        [TestMethod]
        public void PassInEmptyBoardk_ShouldFail()
        {
            // Arrange
            TestData td = new TestData();
            BattleShipBoard bsb_test = new BattleShipBoard(10);

            //Act
            try
            {
                BattleShipStateManager bssm = new BattleShipStateManager(bsb_test);

                // If it gets to this line, no exception was thrown, therefore fail
                Assert.Fail();
            }
            catch (System.ArgumentException)
            {
            }
        }
    }
}
