using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnityIOC;
using EF.Model;

namespace UnityIOC.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private ServiceFactory sf = ServiceFactory.Instance;
        [TestMethod]
        public void TestMethod1()
        {
       //     var container = sf.GetEFService<JDContext>().Container;
        }
    }
}
