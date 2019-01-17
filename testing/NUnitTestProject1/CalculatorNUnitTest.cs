using NUnit.Framework;
using Testing;

namespace Tests
{
    public class CalculatorNUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            // arrange
            var expected = 3.0;

            // act
            var actual = Calculator.Add(1, 2);

            // assert
            Assert.AreEqual(expected,actual);
        }
    }
}