using System;
using Xunit;
using Testing;

namespace XUnitTestProject1
{
    public class CalculatorxUnitTest
    {
        [Fact]
        public void Test1()
        {
            // arrange
            var expected = 3.0;
            // act 

            var actual = Calculator.Add(1, 2);

            // assert

            Assert.Equal(expected, actual);
            
        }
    }
}
