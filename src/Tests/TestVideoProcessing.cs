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
        private LightManager testMan;

        [SetUp]
        public void SetUp()
        {
            testMat = FrameHelper.GetTestMat();

        }

        [TearDown]
        public void TearDown()
        {
            testMat.Dispose();
        }

        [Test]
        public void something()
        {
            Assert.IsNotNull(testMat);
        }


        [Test]
        public void TestDrawnFoundNodes()
        {
            testMan = new LightManager();

            VideoSettings testSet = new VideoSettings();
            VideoProcessing vid = new VideoProcessing(testMan);
            vid.LoadVideo(testSet);

            vid.ProcessFrame(testMat);
            Assert.Greater(testMan.GetLights().Count(), 0, "Lights should have been detected");

            
        }

        
    }
}
