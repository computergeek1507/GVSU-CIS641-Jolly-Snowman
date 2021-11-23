using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Emgu.CV;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Emgu_Test.Tests
{
    [TestFixture]
    public class TestModelExporter
    {
        private Mat testMat;
        private LightManager testMan;
        private VideoSettings testSettings;
        private VideoProcessing testProc;
        private readonly string modelPath = "xmlTest.xmodel";


        [SetUp]
        public void SetUp()
        {
            //Process a known frame

            testMat = FrameHelper.GetTestMat(); 
            testMan = new LightManager();
            testSettings = new VideoSettings();

            testProc = new VideoProcessing(testMan, testSettings);
            //vid.LoadVideo(testSet);

            testProc.ProcessFrame(testMat);
            testMan.ExportModel(modelPath, 1);
        }

        [TearDown]
        public void TearDown()
        {
            testMat.Dispose();
        }

        [Test]
        public void TestModel_FileExists()
        {
            FileAssert.Exists(modelPath);
        }

        [Test]
        public void TestModel_XmlHeader()
        {
            Assert.IsTrue(CheckModelForString("<?xml version=\"1.0\" encoding=\"UTF-8\"?>"));
        }

        [Test]
        public void TestModel_Name()
        {
            Assert.IsTrue(CheckModelForString("name="));
        }

        [Test]
        public void TestModel_Param1()
        {
            Assert.IsTrue(CheckModelForString("parm1="));
        }

        [Test]
        public void TestModel_Param2()
        {
            Assert.IsTrue(CheckModelForString("parm2="));
        }

        [Test]
        public void TestModel_StringType()
        {
            Assert.IsTrue(CheckModelForString("StringType="));
        }

        [Test]
        public void TestModel_Transparency()
        {
            Assert.IsTrue(CheckModelForString("Transparency="));
        }

        [Test]
        public void TestModel_PixelSize()
        {
            Assert.IsTrue(CheckModelForString("PixelSize="));
        }

        [Test]
        public void TestModel_Antialias()
        {
            Assert.IsTrue(CheckModelForString("Antialias="));
        }

        [Test]
        public void TestModel_StrandNames()
        {
            Assert.IsTrue(CheckModelForString("StrandNames="));
        }

        [Test]
        public void TestModel_NodeNames()
        {
            Assert.IsTrue(CheckModelForString("NodeNames="));
        }

        [Test]
        public void TestModel_CustomModel()
        {
            Assert.IsTrue(CheckModelForString("CustomModel="));
        }

        [Test]
        public void TestModel_SourceVersion()
        {
            Assert.IsTrue(CheckModelForString("SourceVersion="));
        }

        [Test]
        public void TestModel_LightLocation()
        {
            Assert.IsTrue(CheckModelForString(" CustomModel=\"1,,,;,,,;,,,\""));

        }

        public bool CheckModelForString(string str)
        {
            List<List<string>> groups = new List<List<string>>();
            foreach (var line in File.ReadAllLines(modelPath))
            {
                if (line.Contains(str))
                {
                    return true;
                }
            }
            return false;
        }




    }
}