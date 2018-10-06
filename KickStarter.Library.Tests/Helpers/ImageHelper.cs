using System;
using System.IO;
using System.Reflection;

namespace KickStarter.Library.Tests.Helpers
{
    public static class ImageHelper
    {
        public static byte[] GetDummyImage()
        {
            var exeDir = Path.GetDirectoryName((new Uri(Assembly.GetExecutingAssembly().CodeBase)).LocalPath);
            var imageFileName = "DefaultUserImage.jpg";

            var imagePath = Path.Combine(exeDir, imageFileName);

            if (File.Exists(imagePath))
            {
                var fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
                var br = new BinaryReader(fs);

                byte[] imageBites = br.ReadBytes((int)fs.Length);
                //Close the BinaryReader
                br.Close();
                //Close the FileStream
                fs.Close();

                return imageBites;
            }
            return null;
        }
    }
}
