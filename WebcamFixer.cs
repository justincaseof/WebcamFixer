using System;
using System.Threading;
using AForge.Video.DirectShow;

namespace WebcamFixer
{
    class WebcamFixer
    {
        static void Main(string[] args)
        {
            FilterInfoCollection filterCol = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterCol)
            {
                VideoCaptureDevice tmp = new VideoCaptureDevice(filterInfo.MonikerString);
                try
                {
                    if (filterInfo.Name == "Microsoft® LifeCam HD-5000") {
                        int focus = 0;
                        CameraControlFlags controlFlags;
                        tmp.GetCameraProperty(CameraControlProperty.Focus, out focus, out controlFlags);

                        Console.WriteLine("WebCam Name: " + filterInfo.Name + " (" + filterInfo.MonikerString + ")");
                        Console.WriteLine("\tfocus: " + focus);
                        Console.WriteLine("\tcontrolFlags: " + controlFlags);
                        
                        // leave focus as is, but disable autofocus
                        Console.WriteLine("--> disabling Autofocus...");
                        tmp.SetCameraProperty(CameraControlProperty.Focus, focus, CameraControlFlags.Manual);
                        Console.WriteLine("--> ...done.");
                    }
                }
                catch { }
            }
        }
    }
}
