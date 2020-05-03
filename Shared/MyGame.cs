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

        SpriteFont font_3;

        public MyGame()
        {
            this.Content.RootDirectory = Environment.CurrentDirectory;
            graphicsDeviceManager = new GraphicsDeviceManager(this);

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
            actualScene = WK.Scene.Scene1;

            spriteBatch = new SpriteBatch(GraphicsDevice);

            this.scenes = new Dictionary<string, IScene>() {
                { WK.Scene.Menu, new Menu(Content) },
                { WK.Scene.Scene1, new Scene1(Content) },
                { WK.Scene.Scene2, new Scene2(Content) }
            };

            font_3 = Content.Load<SpriteFont>("Arial_20");
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
            spriteBatch.DrawString(font_3, "hello", new Vector2(50, 65), Color.Black);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
