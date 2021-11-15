using DirectShowLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Emgu_Test
{
    class CameraManager
    {
        public static List<string> ListOfAttachedCameras()
        {
            List<string> cameras = new List<string>();
            DirectShowLib.DsDevice[] allCameras = DirectShowLib.DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            foreach (var cam in allCameras)
            {
                cameras.Add(cam.Name);
            }
            return cameras;

        }
    }
}
