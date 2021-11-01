using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Emgu_Test.Tests
{
    class VideoHelper
    {
        public static LightManager ProcessVideo(string filename)
        {
            var testMan = new LightManager();

            VideoSettings vidSet = LoadSettings();
            vidSet.FileName = filename;
            VideoProcessing vidProc = new VideoProcessing(testMan,vidSet);
            vidProc.LoadVideo(filename);

            vidProc.ProcessVideo();

            return testMan;
        }

        /**
         * Stolen from MainForm.cs
         */ 
        private static readonly string _appDataFolder = string.Format("{0}{1}{2}", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Path.DirectorySeparatorChar, "Emgu_Test");

        public static VideoSettings LoadSettings()
        {
            var settingFile = _appDataFolder + Path.DirectorySeparatorChar + "settings.xml";

            try
            {
                if (File.Exists(settingFile))//see if file exists
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(VideoSettings));
                    FileStream reader = new FileStream(settingFile, FileMode.Open);
                    var _videoSettings = (VideoSettings)serializer.Deserialize(reader);
                    reader.Close();
                    return _videoSettings;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
