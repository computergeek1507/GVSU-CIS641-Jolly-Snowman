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

        [TearDown]
        public void TearDown()
        {
            testMat.Dispose();
        }

        [Test]
        public void VerifyFrame()
        {
            Assert.IsNotNull(testMat);
        }

        [Test]
        public void TestDrawnFoundNodes()
        {
            LightManager testMan = new LightManager();
            VideoSettings testSet = new VideoSettings();

            VideoProcessing vid = new VideoProcessing(testMan);
            vid.LoadVideo(testSet);

            vid.ProcessFrame(testMat);
            Assert.Greater(testMan.GetLights().Count(), 0, "Lights should have been detected");
        }

        [Test]
        public void TestVideo_BeginningAndOne()
        {
            LightManager testMan = VideoHelper.ProcessVideo( @"../../artifacts/TestVideos/Test_BeginningAndOne.mp4");
            
            Assert.Greater(testMan.GetLights().Count(), 0, "Lights should have been detected");
        }

        [Test]
        public void TestVideo_BeginningAndNone()
        {
            LightManager testMan = VideoHelper.ProcessVideo(@"../../artifacts/TestVideos/Test_BeginningAndNone.mp4");

            Assert.AreEqual(testMan.GetLights().Count(), 0, "No lights should have been detected");
        }

        [Test]
        public void TestVideo_NoBeginningAndOne() // #TODO What is the correct outcome for this test?
        {
            LightManager testMan = VideoHelper.ProcessVideo(@"../../artifacts/TestVideos/Test_NoBeginningAndOne.mp4");

            Assert.AreEqual(testMan.GetLights().Count(), 0, "One light should have been detected, maybe?");
        }
        
    }
}
