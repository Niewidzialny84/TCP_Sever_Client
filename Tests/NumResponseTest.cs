using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCPLib.Response;

namespace Tests
{
    [TestClass]
    public class NumResponseTest
    {
        [TestMethod]
        public void RandomNumberWrongTest()
        {
            NumResponse numResponse = new NumResponse();

            Assert.AreEqual(numResponse.getRand("123","12x"), "Sry, wrong input");
        }

        [TestMethod]
        public void RandomNumberTrueTest()
        {
            NumResponse numResponse = new NumResponse();

            Assert.AreEqual(numResponse.getRand("1", "1"), "1");
        }
    }
}
