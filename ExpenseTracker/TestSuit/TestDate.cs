using ExpenseTracker;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestSuit
{
    [TestClass]
    public class TestDate
    {
        [TestMethod]
        public void TestCheckDayUnder()
        {
            //Arrange
            Date date = new Date();
            date.month = 2;
            date.day = 0;
            date.year = 1999;

            //Act & assert
            Assert.IsTrue(date.CheckMonth());
            Assert.IsFalse(date.CheckDate());
            Assert.IsTrue(date.CheckYear());
        }

        [TestMethod]
        public void TestCheckDayNegative()
        {
            //Arrange
            Date date = new Date();
            date.month = 2;
            date.day = -1;
            date.year = 1999;

            //Act & assert
            Assert.IsTrue(date.CheckMonth());
            Assert.IsFalse(date.CheckDate());
            Assert.IsTrue(date.CheckYear());
        }

        [TestMethod]
        public void TestCheckDayOver()
        {
            //Arrange
            Date date = new Date();
            date.month = 2;
            date.day = 32;
            date.year = 1999;

            //Act & assert
            Assert.IsTrue(date.CheckMonth());
            Assert.IsFalse(date.CheckDate());
            Assert.IsTrue(date.CheckYear());
        }

        [TestMethod]
        public void TestCheckDayCorrect()
        {
            //Arrange
            Date date = new Date();
            date.month = 2;
            date.day = 15;
            date.year = 1999;

            //Act & assert
            Assert.IsTrue(date.CheckMonth());
            Assert.IsTrue(date.CheckDate());
            Assert.IsTrue(date.CheckYear());
        }

        [TestMethod]
        public void TestCheckMonthUnder()
        {
            //Arrange
            Date date = new Date();
            date.month = 0;
            date.day = 1;
            date.year = 1999;

            //Act & assert
            Assert.IsFalse(date.CheckMonth());
            Assert.IsTrue(date.CheckDate());
            Assert.IsTrue(date.CheckYear());
        }

        [TestMethod]
        public void TestCheckMonthOver()
        {
            //Arrange
            Date date = new Date();
            date.month = 13;
            date.day = 1;
            date.year = 1999;

            //Act & assert
            Assert.IsFalse(date.CheckMonth());
            Assert.IsTrue(date.CheckDate());
            Assert.IsTrue(date.CheckYear());
        }

        [TestMethod]
        public void TestCheckFebruaryOver()
        {
            //Arrange
            Date date = new Date();
            date.month = 2;
            date.day = 30;
            date.year = 1999;

            //Act & assert
            Assert.IsTrue(date.CheckMonth());
            Assert.IsFalse(date.CheckDate());
            Assert.IsTrue(date.CheckYear());
        }

        [TestMethod]
        public void TestCheckThirtyOneOver()
        {
            //Arrange
            Date date = new Date();
            date.month = 6;
            date.day = 31;
            date.year = 1999;

            //Act & assert
            Assert.IsTrue(date.CheckMonth());
            Assert.IsFalse(date.CheckDate());
            Assert.IsTrue(date.CheckYear());
        }

        [TestMethod]
        public void TestCheckThirtyOneIn()
        {
            //Arrange
            Date date = new Date();
            date.month = 1;
            date.day = 31;
            date.year = 1999;

            //Act & assert
            Assert.IsTrue(date.CheckMonth());
            Assert.IsTrue(date.CheckDate());
            Assert.IsTrue(date.CheckYear());
        }
    }
}
