using System.Drawing;
using FilterLib;

namespace FilterTest
{
    class Program
    {
        public static void SaveImage(FilterLib.Image<RGBA> image, string path)
        {
            using (Bitmap bm = new Bitmap(image.Width, image.Height))
            {
                for (int x = 0; x < image.Width; x++)
                {
                    for (int y = 0; y < image.Height; y++)
                    {
                        var p = image.GetPixelAt(x, y);
                        Color c = Color.FromArgb(p.IntA, p.IntR, p.IntG, p.IntB);
                        bm.SetPixel(x, y, c);
                    }
                }
                bm.Save(path);
            }
        }

        public static FilterLib.Image<RGBA> Load(string url)
        {
            using (Bitmap bm = new Bitmap(url, false))
            {
                FilterLib.Image<RGBA> img = FilterLib.Image<RGBA>.CreateImage(bm.Width, bm.Height);
                for (int x = 0; x < bm.Width; x++)
                {
                    for (int y = 0; y < bm.Height; y++)
                    {
                        var p = bm.GetPixel(x, y);
                        RGBA c = new RGBA(p.R / 255.0, p.G / 255.0, p.B / 255.0, p.A / 255.0);
                        img.SetPixel(x, y, c);
                    }
                }
                return img;
            }
        }

        static void Main(string[] args)
        {
            var rgba = Load("C:\\Users\\zarate17087\\Desktop\\descarga(1).jpg");
            var rgba2 = Filter.TurnNegative(rgba);
            SaveImage(rgba2, "C:\\Users\\zarate17087\\Desktop\\xd.jpg");
        }       
    }
}
