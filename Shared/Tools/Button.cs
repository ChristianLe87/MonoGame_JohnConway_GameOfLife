using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Button
    {
        Rectangle rectangle;
        Texture2D defaultTexture;
        Texture2D mouseOverTexture;
        MouseState previousMouseState;
        bool isMouseOver;

        string text;
        SpriteFont spriteFont;

        public delegate void DxOnClickAction();

        public Button(Rectangle rectangle, string text, Color defaultColor, Color mouseOverColor)
        {
            this.rectangle = rectangle;
            this.text = text;
            this.defaultTexture = Tools.CreateColorTexture(MyGame.graphicsDeviceManager.GraphicsDevice, defaultColor, 1, 1);
            this.mouseOverTexture = Tools.CreateColorTexture(MyGame.graphicsDeviceManager.GraphicsDevice, mouseOverColor, 1, 1);
            this.isMouseOver = false;
            this.spriteFont = MyGame.contentManager.Load<SpriteFont>("Arial_20");

        }

        public void Update(DxOnClickAction OnClickAction)
        {
            MouseState mouseState = Mouse.GetState();

            if (rectangle.Contains(mouseState.X, mouseState.Y))
            {
                isMouseOver = true;
                if (previousMouseState.LeftButton == ButtonState.Released
                    &&
                    Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    OnClickAction();
                }
            }
            else
            {
                isMouseOver = false;
            }

            previousMouseState = Mouse.GetState();

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isMouseOver)
                spriteBatch.Draw(mouseOverTexture, rectangle, Color.White);
            else
                spriteBatch.Draw(defaultTexture, rectangle, Color.White);


            spriteBatch.DrawString(spriteFont, text, new Vector2(rectangle.X, rectangle.Y), Color.Black);

        }
    }
}