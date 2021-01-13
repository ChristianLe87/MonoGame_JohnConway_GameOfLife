using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    internal class Menu : IScene
    {
        Button GameButton;
        Button AboutButton;

        Texture2D backgroundTexture;

        public void Initialize()
        {
            GameButton = new Button(
                                    rectangle: new Rectangle(200, 100, 100, 50),
                                    text: "Game 1",
                                    defaultTexture: Tools.CreateColorTexture(MyGame.graphicsDeviceManager.GraphicsDevice, Color.Green, 10, 10),
                                    mouseOverTexture: Tools.CreateColorTexture(MyGame.graphicsDeviceManager.GraphicsDevice, Color.DarkGreen, 10, 10),
                                    spriteFont: Tools.GetFont(MyGame.contentManager, WK.Font.Arial_10),
                                    fontColor: Color.Black
                                    );

            AboutButton = new Button(
                                    rectangle: new Rectangle(200, 400, 100, 50),
                                    text: "About",
                                    defaultTexture: Tools.CreateColorTexture(MyGame.graphicsDeviceManager.GraphicsDevice, Color.Green, 10, 10),
                                    mouseOverTexture: Tools.CreateColorTexture(MyGame.graphicsDeviceManager.GraphicsDevice, Color.DarkGreen, 10, 10),
                                    spriteFont: Tools.GetFont(MyGame.contentManager, WK.Font.Arial_10),
                                    fontColor: Color.Black
                                    );

            backgroundTexture = Tools.CreateColorTexture(MyGame.graphicsDeviceManager.GraphicsDevice, Color.LightGreen, WK.Default.CanvasHeight, WK.Default.CanvasWidth);
        }

        public void Update(GameTime gameTime)
        {
            GameButton.Update(Game1ButtonLogic);
            AboutButton.Update(AboutButtonLogic);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, new Vector2(0, 0), Color.White);
            GameButton.Draw(spriteBatch);
            AboutButton.Draw(spriteBatch);
        }


        public void Game1ButtonLogic()
        {
            Console.WriteLine("Play");
            MyGame.actualScene = WK.Scene.Scene1;
            MyGame.scenes[MyGame.actualScene].Initialize();
        }

        public void AboutButtonLogic()
        {
            Console.WriteLine("About");
            MyGame.actualScene = WK.Scene.About;
            MyGame.scenes[MyGame.actualScene].Initialize();
        }
    }
}
