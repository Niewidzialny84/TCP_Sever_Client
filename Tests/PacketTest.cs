using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCPLib.PacketLib;

namespace Tests
{
    [TestClass]
    public class PacketTest
    {
        [TestMethod]
        public void PacketSendTest()
        {
            Packet a = new PacketSend("a");

            Assert.AreEqual(a.Message, "a\n\r");
        }

        [TestMethod]
        public void PacketReciveTest()
        {
            Packet a = new PacketRecive(new byte[] { (byte)'a', (byte)'\n', (byte)'\r' },3);

            Assert.AreEqual(a.Message, "a");
        }

    }
}
