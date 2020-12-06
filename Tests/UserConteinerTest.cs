using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCPLib;

namespace Tests
{
    [TestClass]
    public class UserConteinerTest
    {
        private UserContainer c;

        [ClassInitialize]
        public void initialize()
        {
           c = new UserContainer();
        }

        [TestMethod]
        public void AdminTest()
        {
            Assert.IsTrue(c.CheckCredentials("admin", "admin"));
            Assert.IsFalse(c.CheckCredentials("admin", "qwerty"));
        }

        [TestMethod]
        public void UserTest()
        {
            Assert.IsTrue(c.CheckCredentials("user5", "qwerty"));
            Assert.IsFalse(c.CheckCredentials("user5", "qwerty2"));
        }

        [TestMethod]
        public void RoleTest()
        {
            Assert.IsTrue(c.GetPermission("admin").Equals("True"));
            Assert.IsTrue(c.GetPermission("user5").Equals("False"));
        }

    }
}
