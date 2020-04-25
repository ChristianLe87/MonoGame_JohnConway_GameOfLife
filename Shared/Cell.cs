using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Cell
    {
        Texture2D aliveTexture;
        Texture2D deadTexture;
        Vector2 position;

        public bool isAlive;

        public Cell(Vector2 position, bool isAlive, Color aliveColor, Color deadColor)
        {
            this.position = position;
            this.isAlive = isAlive;

            this.aliveTexture = Tools.CreateColorTexture(aliveColor, 10, 10);
            this.deadTexture = Tools.CreateColorTexture(deadColor, 10, 10);
        }

        internal void Update()
        {
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            if (isAlive)
            {
                spriteBatch.Draw(aliveTexture, position, Color.White);
            }
            else
            {
                spriteBatch.Draw(deadTexture, position, Color.White);
            }
        }
    }
}
