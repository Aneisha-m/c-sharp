using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest_01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_01.Tests
{
    [TestClass()]
    public class xTests
    {
        [TestMethod()]
        public void ChangeYTest()
        {
            int expected = 10;
            var object01 = new x();
            // act

            Assert.IsTrue(false);

            object01.ChangeY();
            int actual = object01.y;
            Assert.IsTrue(actual <= expected);

            object01.ChangeY();
            actual = object01.y;
            Assert.IsTrue(actual <= expected);

            object01.ChangeY();
            actual = object01.y;
            Assert.IsTrue(actual <= expected);

            object01.ChangeY();
            actual = object01.y;
            Assert.IsTrue(actual <= expected);

            object01.ChangeY();
            actual = object01.y;
            Assert.IsTrue(actual <= expected);

            object01.ChangeY();
            actual = object01.y;
            Assert.IsTrue(actual <= expected);

            object01.ChangeY();
            actual = object01.y;
            Assert.IsTrue(actual <= expected);

            object01.ChangeY();
            actual = object01.y;
            Assert.IsTrue(actual <= expected);

            object01.ChangeY();
            actual = object01.y;
            Assert.IsTrue(actual <= expected);

            object01.ChangeY();
            actual = object01.y;
            Assert.IsTrue(actual <= expected);

            object01.ChangeY();
            actual = object01.y;
            Assert.IsTrue(actual <= expected);

            object01.ChangeY();
            actual = object01.y;
            Assert.IsTrue(actual <= expected);

            Assert.IsTrue(actual <= 10);
        }
    }
}