﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Cell
    {
        Texture2D aliveTexture;
        Texture2D deadTexture;
        public Rectangle rectangle;

        public bool isAlive;

        public bool nextGenerationState;

        public Cell(Rectangle rectangle, bool isAlive)
        {
            this.rectangle = rectangle;
            this.isAlive = isAlive;

            this.aliveTexture = Tools.CreateColorTexture(Color.Green, rectangle.Width, rectangle.Height);
            this.deadTexture = Tools.CreateColorTexture(Color.Brown, rectangle.Width, rectangle.Height);
        }

        internal void Update()
        {
            MouseState mouseState = Mouse.GetState();

            int mousePosX = mouseState.Position.X;
            int mousePosY = mouseState.Position.Y;

            if (
                    mousePosX < rectangle.X + 10 &&
                    mousePosX > rectangle.X &&
                    mousePosY < rectangle.Y + 10 &&
                    mousePosY > rectangle.Y
                )
            {
                if (mouseState.RightButton == ButtonState.Pressed)
                {
                    isAlive = false;
                }
                else if(mouseState.LeftButton == ButtonState.Pressed)
                {
                    isAlive = true;
                }
            }
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            if (isAlive)
            {
                spriteBatch.Draw(aliveTexture, rectangle, Color.White);
            }
            else
            {
                spriteBatch.Draw(deadTexture, rectangle, Color.White);
            }
        }

        internal void Evolve()
        {
            this.isAlive = this.nextGenerationState;
        }

    }
}
