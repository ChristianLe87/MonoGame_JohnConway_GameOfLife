using System;
using System.Collections.Generic;
using System.IO;
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
        public static Dictionary<string, IScene> scenes;

        // Statics
        public static GraphicsDeviceManager graphicsDeviceManager;
        public static bool soundEffectsOn = true;

        public MyGame()
        {
            // Window
            MyGame.graphicsDeviceManager = new GraphicsDeviceManager(this);
            MyGame.graphicsDeviceManager.PreferredBackBufferWidth = WK.Default.CanvasWidth;
            MyGame.graphicsDeviceManager.PreferredBackBufferHeight = WK.Default.CanvasHeight;
            MyGame.graphicsDeviceManager.ApplyChanges();

            // FPS
            base.IsFixedTimeStep = true;
            double fps = 60d;
            base.TargetElapsedTime = TimeSpan.FromSeconds(1d / fps);

            // Content
            string absolutePath = Path.Combine(Environment.CurrentDirectory, "Content");
            base.Content.RootDirectory = absolutePath;
            MyGame.contentManager = base.Content;

            base.IsMouseVisible = true;

            MyGame.actualScene = WK.Scene.Intro;

            MyGame.scenes = new Dictionary<string, IScene>() {
                { WK.Scene.Intro, new Intro() },
                { WK.Scene.Menu, new Menu() },
                { WK.Scene.Scene1, new Game_1() },
                { WK.Scene.About, new About() }
            };

            base.Initialize();
        }


        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(GraphicsDevice);
        }


        protected override void Update(GameTime gameTime)
        {
            MyGame.scenes[actualScene].Update(gameTime);

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