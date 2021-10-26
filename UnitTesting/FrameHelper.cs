using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace UnitTesting
{
    public class FrameHelper
    {

        public static Bitmap GetTestBitmap()
        {
            var testSrc = CreateBitmapSource(System.Windows.Media.Color.FromRgb(0, 0, 0));
            Bitmap testImg = GetFromSource(testSrc);

            using (Graphics myGraph = Graphics.FromImage(testImg)) { 

                GraphicsExtensions.DrawCircle(myGraph, testImg.Width / 2, testImg.Height / 2, 20);
                GraphicsExtensions.FillCircle(myGraph, testImg.Width / 2, testImg.Height / 2, 20);

                myGraph.Save();
            }

            //testImg.Save(@"C:\Users\%User%\Downloads\testImage.bmp", ImageFormat.Bmp);
            return testImg;
            
        }

        private static BitmapSource CreateBitmapSource(System.Windows.Media.Color color)
        {
            int width = 1920;
            int height = 1080;
            int stride = width / 8;
            byte[] pixels = new byte[height * stride];

            List<System.Windows.Media.Color> colors = new List<System.Windows.Media.Color>();
            colors.Add(color);
            BitmapPalette myPalette = new BitmapPalette(colors);

            BitmapSource image = BitmapSource.Create(
                width,
                height,
                96,
                96,
                PixelFormats.Indexed1,
                myPalette,
                pixels,
                stride);

            return image;
        }

        /// <summary>
        /// Convert a BitmapSource into a bitmap image.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private static Bitmap GetFromSource(BitmapSource source)
        {
            Bitmap bmp = new Bitmap(
                source.PixelWidth,
                source.PixelHeight,
                System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            BitmapData data = bmp.LockBits(
                new Rectangle(System.Drawing.Point.Empty, bmp.Size),
                ImageLockMode.WriteOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            source.CopyPixels(
                Int32Rect.Empty,
                data.Scan0,
                data.Height * data.Stride,
                data.Stride);
            bmp.UnlockBits(data);
            return bmp;
        }
    }

    /// <summary>
    /// This class is used for drawing circles on Graphics
    /// </summary>
    public static class GraphicsExtensions
    {
        public static System.Drawing.Pen _Pen = new System.Drawing.Pen(System.Drawing.Color.White, 10);
        public static SolidBrush _Brush = new SolidBrush(System.Drawing.Color.White);

        public static void DrawCircle(this Graphics g,
                                      float centerX, float centerY, float radius)
        {
            g.DrawEllipse(_Pen, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }

        public static void FillCircle(this Graphics g,
                                      float centerX, float centerY, float radius)
        {
            g.FillEllipse(_Brush, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }
    }
}
