using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Emgu.CV;

namespace Emgu_Test.Tests
{
    [TestFixture]
    public class TestVideoProcessing
    {
        private Mat testMat;

        [SetUp]
        public void SetUp()
        {
            testMat = FrameHelper.GetTestMat();
            
        }

        [Test]
        public void something()
        {
            Assert.IsNotNull(testMat);
        }

        
    }
}
