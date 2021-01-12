using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    internal class About : IScene
    {
        Text text;
        Text specialThanks;

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
            this.menuButton = new Button(new Rectangle(200, 350, 100, 50), "Menu", Color.Green, Color.DarkGreen);

            this.text = new Text(WK.Font.Arial_15, new Vector2(20, 50), aboutText);
            this.specialThanks = new Text(WK.Font.Arial_10, new Vector2(20, 450), specialThanksText);

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
            text.Draw(spriteBatch, Color.Black);
            specialThanks.Draw(spriteBatch, Color.Black);
        }

        public void MenuButtonLogic()
        {
            Console.WriteLine("Menu");
            MyGame.actualScene = WK.Scene.Menu;
        }


    }
}