using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Tools
    {
        public static Texture2D CreateColorTexture(Color color, int width, int height)
        {
            Texture2D newTexture = new Texture2D(MyGame.graphicsDeviceManager.GraphicsDevice, width, height, false, SurfaceFormat.Color);
            Color[] colorData = new Color[width * height];
            for (int i = 0; i < width * height; i++)
            {
                colorData[i] = color;
            }

            newTexture.SetData(colorData);

            return newTexture;
        }


        internal static Texture2D GetImageTexture(string imageName)
        {
            string relativePath = $"{imageName}.png";



#if __MACOS__
            string absolutePath = new DirectoryInfo(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, relativePath))).ToString();
#else
            string s1 = Assembly.GetExecutingAssembly().Location;
            string s2 = Assembly.GetExecutingAssembly().ManifestModule.Name;
            bool first = true;
            string absolutePath = Regex.Replace(s1, s2, (m) => {
                if (first)
                {
                    first = false;
                    return "";
                }
                return s2;
            });
            absolutePath = absolutePath + relativePath;
#endif



            FileStream fileStream = new FileStream(absolutePath, FileMode.Open);

            var result = Texture2D.FromStream(MyGame.graphicsDeviceManager.GraphicsDevice, fileStream);
            fileStream.Dispose();

            return result;
        }


    }
}
