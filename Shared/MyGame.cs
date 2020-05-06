using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class MyGame : Game
    {
        SpriteBatch spriteBatch;
        public static ContentManager contentManager;

        // Levels
        public static string actualScene;
        Dictionary<string, IScene> scenes;

        // Statics
        public static GraphicsDeviceManager graphicsDeviceManager;
        public static bool soundEffectsOn = true;
        public const int canvasWidth = 500;
        public const int canvasHeight = 500;

        public MyGame()
        {


#if __MACOS__
            this.Content.RootDirectory = Environment.CurrentDirectory;

#else
            string s1 = Assembly.GetExecutingAssembly().Location;
            string s2 = Assembly.GetExecutingAssembly().ManifestModule.Name;
            bool first = true;
            string s3 = Regex.Replace(s1, s2, (m) =>
            {
                if (first)
                {
                    first = false;
                    return "";
                }
                return s2;
            });

            this.Content.RootDirectory = s3;
#endif







            graphicsDeviceManager = new GraphicsDeviceManager(this);
            contentManager = this.Content;


            // FPS
            this.IsFixedTimeStep = true;
            double fps = 60d;
            this.TargetElapsedTime = TimeSpan.FromSeconds(1d / fps);

            // Window size
            graphicsDeviceManager.PreferredBackBufferWidth = canvasWidth;
            graphicsDeviceManager.PreferredBackBufferHeight = canvasHeight;
        }


        protected override void Initialize()
        {
            base.Initialize();
        }


        protected override void LoadContent()
        {
            actualScene = WK.Scene.Intro;

            spriteBatch = new SpriteBatch(GraphicsDevice);

            this.scenes = new Dictionary<string, IScene>() {
                { WK.Scene.Intro, new Intro() },
                { WK.Scene.Menu, new Menu() },
                { WK.Scene.Scene1, new Scene1() },
                { WK.Scene.Scene2, new Scene2() },
                { WK.Scene.About, new About() }
            };

        }


        protected override void Update(GameTime gameTime)
        {
            Console.WriteLine($"===== Running at FPS: {1f / (gameTime.ElapsedGameTime.Milliseconds / 1000f)} =====");

            scenes[actualScene].Update(gameTime);

            if (actualScene == WK.Scene.Menu)
                this.IsMouseVisible = true;
            else
                this.IsMouseVisible = true;

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            graphicsDeviceManager.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            scenes[actualScene].Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}