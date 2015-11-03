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
        [Test]
        public void FakeTest()
        {
            int numberOne = 1;
            int numberTwo = 2;

            Assert.AreNotEqual(numberOne, numberTwo);
        }
    }
}
