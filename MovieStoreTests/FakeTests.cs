using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MovieStoreTests
{
    [TestFixture]
    public class FakeTests
    {
        // This test will pass
        [Test]
        public void FakeTestOne()
        {
            int numberOne = 1;
            int numberTwo = 2;

            Assert.AreNotEqual(numberOne, numberTwo);
        }

        // This test will fail
        [Test]
        public void FakeTestTwo()
        {
            int numberOne = 1;
            int numberTwo = 2;

            Assert.AreEqual(numberOne, numberTwo);
        }
    }
}
