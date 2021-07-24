using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlareBattleShip.Util;

namespace FlareBattleShipTester
{
    [TestClass]
    public class HelperTester
    {
        [TestMethod]
        public void FormKetReturnsCorrectString_ShouldPass()
        {
            // Arrange
            int start = 7;
            int end = 9;

            //Act
            string result = Helper.FormKey(start, end);

            //Assert
            Assert.AreEqual(result, "0007-0009");
        }

        [TestMethod]
        public void GetRandomInvalidArgument_ShouldFail()
        {
            // Arrange
            int start = 7;
            int end = 9;

            //Act
            try
            {
                int result = Helper.GetRandom(end, start);
                // If it gets to this line, no exception was thrown, therefore fail
                Assert.Fail(); 
            }
            catch (System.ArgumentException ex)
            {
                //Assert
                StringAssert.Contains(ex.Message, "GetRandom");
            }
        }

        [TestMethod]
        public void GetCharFromCellEnumPassInvalid_ShouldFail()
        {
            // Arrange


            //Act
            try
            {
                char result = Helper.GetCharFromCellEnum((Enums.CellState)7);
                // If it gets to this line, no exception was thrown, therefore fail
                Assert.Fail();
            }
            catch (System.ArgumentException)
            {
            }
        }

    }
}
