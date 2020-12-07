using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCPLib.Tools;

namespace Tests
{
    [TestClass]
    public class UnitTestRandGen
    {
        [TestMethod]
        public void TestRandInt()
        {
            RandGen g = new RandGen();
            int minRange = 0;
            int maxRange = 100;
            int result = g.randInt(0, 100);

            Console.Write(minRange + " " + maxRange + " " + result);
          
            Assert.IsTrue((result >= minRange && result <= maxRange), "Wrong rand num: " + result, new Object[]{result});
            Assert.IsFalse((result < minRange || result > maxRange), "Wrong rand num: " + result, new Object[] {result});
        }
    }
}                                            
