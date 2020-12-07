using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCPLib.AsyncServer;
using TCPLib.PacketLib;

namespace Tests
{
    [TestClass]
    public class HandlerTest
    {
        [TestMethod]
        public void HandleTest()
        {
            CommandHandler h = new CommandHandler();
            
            Assert.AreEqual(h.Handle("hi").Message, "hello\n\r");
            Assert.AreNotEqual(h.Handle("hello").Message, "a\n\r");
        }
    }
}
