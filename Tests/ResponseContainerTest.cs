using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCPLib.Response;

namespace Tests
{
    [TestClass]
    public class ResponseContainerTest
    {
        public static ResponseContainer c;

        [ClassInitialize]
        public static void initialize(TestContext context)
        {
            c = new ResponseContainer();
        }

        [TestMethod]
        public void ResponseTest()
        {
            Assert.AreEqual(c.GetResponse("hi"), "hello");
            Assert.AreNotEqual(c.GetResponse("hii"), "hello");
        }

        [TestMethod]
        public void ResponseEqualTest()
        {
            Response r = new Response("hello", "hello");
            Response l = new Response("hello", "hello");
            Response m = new Response("hello", "o");

            Assert.IsTrue(r.Input.Equals(l.Input));
            Assert.IsFalse(r.Output.Equals(m.Output));
        }
    }
}
