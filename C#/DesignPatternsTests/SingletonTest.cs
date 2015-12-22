using System;
using DesignPatterns.Singleton;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternsTests
{
    [TestClass]
    public class SingletonTest
    {
        [TestMethod]
        [TestCategory("Singleton")]
        public void NoThreadProtection()
        {
            NotThreadSafe a = NotThreadSafe.GetInstance();
            NotThreadSafe b = NotThreadSafe.GetInstance();

            Assert.AreEqual(a.ID, b.ID);
        }

        [TestMethod]
        [TestCategory("Singleton")]
        public void VolitleThreadSage()
        {
            VolatileThreadSafe a = VolatileThreadSafe.GetInstance();
            VolatileThreadSafe b = VolatileThreadSafe.GetInstance();

            Assert.AreEqual(a.ID, b.ID);
        }

        [TestMethod]
        [TestCategory("Singleton")]
        public void LockThreadSage()
        {
            LockThreadSafe a = LockThreadSafe.GetInstance();
            LockThreadSafe b = LockThreadSafe.GetInstance();

            Assert.AreEqual(a.ID, b.ID);
        }
    }
}
