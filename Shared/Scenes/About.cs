using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    internal class About : IScene
    {
        private ContentManager content;

        Button MenuButton;


        public About(ContentManager content)
        {
            this.content = content;
            MenuButton = new Button(new Rectangle(50, 50, 100, 50), "Menu", Color.Gray, Color.DarkGray);
        }

        public void Update(GameTime gameTime)
        {
            MenuButton.Update(MenuButtonLogic);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            MenuButton.Draw(spriteBatch);
        }

        public void MenuButtonLogic()
        {
            Console.WriteLine("Menu");
            MyGame.actualScene = WK.Scene.Menu;
        }


    }
}