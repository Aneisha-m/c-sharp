using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testing;

namespace UnitTestProject1
{
    [TestClass]
    public class CalculatorMSTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            // arrange
            double expected = 3.0;

            // act
            double actual = Calculator.Add(1, 2);

            // assert
            Assert.AreEqual(expected, actual);

        }
    }
}
