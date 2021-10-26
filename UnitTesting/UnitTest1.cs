using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            FrameHelper helper = new FrameHelper();
            Assert.IsNotNull(helper);
        }
    }
}
