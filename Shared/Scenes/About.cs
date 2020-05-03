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

        string aboutText =
            "Inspired by the Game Of Life Game,\n" +
            "From the British mathematician John Horton Conway\n\n" +
            "I coded to keep my C# skills on shape\n" +
            "Created using MonoGame\n\n" +
            "I know, I know...\n" +
            "I need a designer...";

        string specialThanksText =
            "Special thanks to Sascha 'OP'";


        private ContentManager content;

        Button menuButton;


        public About(ContentManager content)
        {
            this.content = content;
            this.menuButton = new Button(new Rectangle(50, 50, 100, 50), "Menu", Color.Gray, Color.DarkGray);
            this.text = new Text(WK.Font.Arial_15, new Vector2(20, 50), aboutText);
            this.specialThanks = new Text(WK.Font.Arial_10, new Vector2(20, 450), specialThanksText);
        }

        public void Update(GameTime gameTime)
        {
            menuButton.Update(MenuButtonLogic);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
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