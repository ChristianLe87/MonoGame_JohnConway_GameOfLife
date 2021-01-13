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
            "-> Special thanks to Sascha 'OP'";


        Button menuButton;

        public void Initialize()
        {
            this.menuButton = new Button(
                                        rectangle: new Rectangle(200, 350, 100, 50),
                                        text: "Menu",
                                        defaultTexture: Tools.CreateColorTexture(MyGame.graphicsDeviceManager.GraphicsDevice, Color.Green),
                                        mouseOverTexture: Tools.CreateColorTexture(MyGame.graphicsDeviceManager.GraphicsDevice, Color.DarkGreen),
                                        spriteFont: Tools.GetFont(MyGame.contentManager, WK.Font.Arial_10),
                                        fontColor: Color.Black
                                        );

            this.text = new Label(
                                rectangle: new Rectangle(0, 100, WK.Default.CanvasWidth, WK.Default.CanvasHeight - 300),
                                spriteFont: Tools.GetFont(MyGame.contentManager, WK.Font.Arial_15),
                                text: aboutText,
                                textAlignment: Label.TextAlignment.Top_Center,
                                fontColor: Color.Black,
                                lineSpacing: 20
                                );

            this.specialThanks = new Label(
                                        rectangle: new Rectangle(0, 0, WK.Default.CanvasWidth, WK.Default.CanvasHeight),
                                        spriteFont: Tools.GetFont(MyGame.contentManager, WK.Font.Arial_10),
                                        text: specialThanksText,
                                        textAlignment: Label.TextAlignment.Down_Left,
                                        fontColor: Color.Black
                                        );

            backgroundTexture = Tools.CreateColorTexture(MyGame.graphicsDeviceManager.GraphicsDevice, Color.LightGreen, WK.Default.CanvasHeight, WK.Default.CanvasWidth);
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
            MyGame.scenes[MyGame.actualScene].Initialize();
        }
    }
}