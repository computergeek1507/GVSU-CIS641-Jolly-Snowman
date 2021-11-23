using DirectShowLib;
using System.Collections.Generic;

namespace Emgu_Test
{
    class CameraManager
    {
        /// <summary>
        /// Get a List of all the Local Cameras from Microsoft's Directshow library 
        /// </summary>
        /// <returns>list of camera names</returns>
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
