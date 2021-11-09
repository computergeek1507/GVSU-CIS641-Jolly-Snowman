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
        public void TestFrame_One()
        {
            LightManager testMan = new LightManager();
            VideoSettings testSet = new VideoSettings();

            VideoProcessing vid = new VideoProcessing(testMan, testSet);
            //vid.LoadVideo(testSet);

            vid.ProcessFrame(testMat);
            Assert.AreEqual(1, testMan.GetLights().Count(), "Lights should have been detected");
        }

        [Test]
        public void TestVideo_ManyLEDsThenOne()
        {
            LightManager testMan = VideoHelper.ProcessVideo(@"..\..\..\..\..\artifacts\TestVideos\Test_BeginningAndOne.mp4");

            Assert.AreEqual(1, testMan.GetLights().Count(), "Lights should have been detected");
        }

        [Test]
        public void TestVideo_ManyLEDs()
        {
            LightManager testMan = VideoHelper.ProcessVideo(@"..\..\..\..\..\artifacts/TestVideos/Test_BeginningAndNone.mp4");

            Assert.AreEqual(0, testMan.GetLights().Count(), "No lights should have been detected");
        }

        [Test]
        public void TestVideo_OneLED() //#TODO What is the correct outcome for this test?
        {
            LightManager testMan = VideoHelper.ProcessVideo(@"..\..\..\..\..\artifacts/TestVideos/Test_NoBeginningAndOne.mp4");

            Assert.AreEqual(1, testMan.GetLights().Count(), "One light should have been detected");
        }

        [Test]
        public void TestLoadVideo()
        {
            LightManager lightMan = new LightManager();

            VideoSettings vidSet = VideoHelper.LoadSettings();
            vidSet.FileName = @"..\..\..\..\..\artifacts/TestVideos/Test_NoBeginningAndOne.mp4";
            VideoProcessing vidProc = new VideoProcessing(lightMan, vidSet);
            vidProc.LoadVideo(vidSet.FileName);
        }

    }
}