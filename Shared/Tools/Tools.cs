using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Tools
    {
        /// <summary>
        /// Create a new Texture2D from a Color
        /// </summary>
        public static Texture2D CreateColorTexture(GraphicsDevice graphicsDevice, Color color, int Width = 1, int Height = 1)
        {
            Texture2D texture2D = new Texture2D(graphicsDevice, Width, Height, false, SurfaceFormat.Color);
            Color[] colors = new Color[Width * Height];

            // Set each pixel to color
            colors = colors
                        .Select(x => x = color)
                        .ToArray();

            texture2D.SetData(colors);

            return texture2D;
        }

        /// <summary>
        /// Generate a new texture from a PNG file
        /// </summary>
        public static Texture2D GetTexture(GraphicsDevice graphicsDevice, ContentManager contentManager, string imageName, string folder = "")
        {
            string absolutePath = new DirectoryInfo(Path.Combine(Path.Combine(contentManager.RootDirectory, folder), $"{imageName}.png")).ToString();

            FileStream fileStream = new FileStream(absolutePath, FileMode.Open);

            var result = Texture2D.FromStream(graphicsDevice, fileStream);
            fileStream.Dispose();

            return result;
        }
    }
}
