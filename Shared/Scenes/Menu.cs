using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    internal class Menu : IScene
    {
        Button Game1Button;
        Button Game2Button;
        Button AboutButton;

        Texture2D backgroundTexture;

        public Menu()
        {
            Game1Button = new Button(new Rectangle(200, 100, 100, 50),"Game 1", Color.Green, Color.DarkGreen);
            Game2Button = new Button(new Rectangle(200, 200, 100, 50), "Game 2", Color.Green, Color.DarkGreen);
            AboutButton = new Button(new Rectangle(200, 400, 100, 50), "About", Color.Green, Color.DarkGreen);

            backgroundTexture = Tools.CreateColorTexture(Color.LightGreen, MyGame.canvasHeight, MyGame.canvasWidth);
        }

        public void Update(GameTime gameTime)
        {
            Game1Button.Update(Game1ButtonLogic);
            Game2Button.Update(Game2ButtonLogic);
            AboutButton.Update(AboutButtonLogic);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, new Vector2(0,0), Color.White);
            Game1Button.Draw(spriteBatch);
            Game2Button.Draw(spriteBatch);
            AboutButton.Draw(spriteBatch);
        }


        public void Game1ButtonLogic()
        {
            Console.WriteLine("Play");
            MyGame.actualScene = WK.Scene.Scene1;
        }

        public void Game2ButtonLogic()
        {
            Console.WriteLine("Play");
            MyGame.actualScene = WK.Scene.Scene2;
        }

        public void AboutButtonLogic()
        {
            Console.WriteLine("About");
            MyGame.actualScene = WK.Scene.About;
        }

    }
}