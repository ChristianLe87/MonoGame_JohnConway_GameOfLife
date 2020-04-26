using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class MyGame : Game
    {
        SpriteBatch spriteBatch;

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
            string relativePath = $"../../../../MonoGame_JohnConway_GameOfLife/Assets/";
            string absolutePath = new DirectoryInfo(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, relativePath))).ToString();
            this.Content.RootDirectory = absolutePath;
            graphicsDeviceManager = new GraphicsDeviceManager(this);

            // FPS
            this.IsFixedTimeStep = true;
            double fps = 2d;
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
            actualScene = WK.Scene.Game;

            spriteBatch = new SpriteBatch(GraphicsDevice);

            this.scenes = new Dictionary<string, IScene>() {
                { WK.Scene.Menu, new Menu(Content) },
                { WK.Scene.Game, new Scene1(Content) }
            };
        }


        protected override void Update(GameTime gameTime)
        {
            Console.WriteLine($"===== Running at FPS: {1f / (gameTime.ElapsedGameTime.Milliseconds / 1000f)} =====");

            scenes[actualScene].Update();

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
