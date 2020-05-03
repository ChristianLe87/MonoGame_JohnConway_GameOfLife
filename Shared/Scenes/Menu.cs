using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    internal class Menu : IScene
    {
        private ContentManager content;

        Button Game1Button;
        Button Game2Button;
        Button AboutButton;

        public Menu(ContentManager content)
        {
            this.content = content;
            Game1Button = new Button(new Rectangle(50, 50, 100, 50),"Game 1", Color.Gray, Color.DarkGray);
            Game2Button = new Button(new Rectangle(50, 150, 100, 50), "Game 2", Color.Gray, Color.DarkGray);
            AboutButton = new Button(new Rectangle(50, 250, 100, 50), "About", Color.Gray, Color.DarkGray);
        }

        public void Update(GameTime gameTime)
        {
            Game1Button.Update(Game1ButtonLogic);
            Game2Button.Update(Game2ButtonLogic);
            AboutButton.Update(AboutButtonLogic);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
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