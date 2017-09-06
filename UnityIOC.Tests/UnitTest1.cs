using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnityIOC;
using EF.Model;

namespace UnityIOC.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var sf = ServiceFactory.Instance;
            Assert.IsNotNull(sf);
        }
    }
}
