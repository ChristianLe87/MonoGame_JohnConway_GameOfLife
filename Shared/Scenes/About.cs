using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    internal class About : IScene
    {
        Text text;

        string aboutText =
            "Inspired by the Game Of Life Game,\n" +
            "from the British mathematician John Horton Conway\n\n" +
            "I coded to keep my C# skills on shape\n" +
            "Created using MonoGame\n\n" +
            "I know, I know...\n" +
            "I need a designer...";


        private ContentManager content;

        Button menuButton;


        public About(ContentManager content)
        {
            this.content = content;
            this.menuButton = new Button(new Rectangle(50, 50, 100, 50), "Menu", Color.Gray, Color.DarkGray);
            this.text = new Text(WK.Font.Arial_20, new Vector2(20, 50), aboutText);

        }

        public void Update(GameTime gameTime)
        {
            menuButton.Update(MenuButtonLogic);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            menuButton.Draw(spriteBatch);
            text.Draw(spriteBatch, Color.Black);
        }

        public void MenuButtonLogic()
        {
            Console.WriteLine("Menu");
            MyGame.actualScene = WK.Scene.Menu;
        }


    }
}