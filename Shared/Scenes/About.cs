using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    internal class About : IScene
    {
        Label text;
        Label specialThanks;

        Texture2D backgroundTexture;

        string aboutText =
            "Inspired by the Game Of Life Game,\n" +
            "From the British mathematician John Horton Conway\n\n" +
            "I coded to keep my C# skills on shape\n" +
            "Created using MonoGame\n\n" +
            "I know, I know...\n" +
            "I need a designer...";

        string specialThanksText =
            "Special thanks to Sascha 'OP'";


        Button menuButton;


        public About()
        {
            this.menuButton = new Button(
                                    rectangle: new Rectangle(200, 350, 100, 50),
                                    text: "Menu",
                                    defaultTexture: Tools.CreateColorTexture(MyGame.graphicsDeviceManager.GraphicsDevice, Color.Green, 10, 10),
                                    mouseOverTexture: Tools.CreateColorTexture(MyGame.graphicsDeviceManager.GraphicsDevice, Color.DarkGreen, 10, 10),
                                    spriteFont: Tools.GetFont(MyGame.contentManager, WK.Font.Arial_10),
                                    fontColor: Color.Black
                                    );

            this.text = new Label(new Rectangle(20, 20, 200, 200), Tools.GetFont(MyGame.contentManager, WK.Font.Arial_15), aboutText, Label.TextAlignment.Midle_Center, Color.Black);
            this.specialThanks = new Label(new Rectangle(20, 450, 200, 200), Tools.GetFont(MyGame.contentManager, WK.Font.Arial_10), specialThanksText, Label.TextAlignment.Midle_Center, Color.Black);

            backgroundTexture = Tools.CreateColorTexture(MyGame.graphicsDeviceManager.GraphicsDevice, Color.LightGreen, MyGame.canvasHeight, MyGame.canvasWidth);
        }

        public void Update(GameTime gameTime)
        {
            menuButton.Update(MenuButtonLogic);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, new Vector2(0, 0), Color.White);

            menuButton.Draw(spriteBatch);
            text.Draw(spriteBatch);
            specialThanks.Draw(spriteBatch);
        }

        public void MenuButtonLogic()
        {
            Console.WriteLine("Menu");
            MyGame.actualScene = WK.Scene.Menu;
        }


    }
}