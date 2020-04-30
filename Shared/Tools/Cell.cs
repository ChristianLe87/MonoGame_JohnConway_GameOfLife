using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public enum State
    {
        Dead,
        Middle,
        Alive
    }

    public class Cell
    {
        Texture2D aliveTexture;
        Texture2D middleTexture;
        Texture2D deadTexture;

        public Rectangle rectangle;
        public List<Cell> neighbors;
        public State isAlive;

        public State nextGenerationState;

        public Cell(Rectangle rectangle, State isAlive)
        {
            this.rectangle = rectangle;
            this.isAlive = isAlive;

            this.aliveTexture = Tools.CreateColorTexture(Color.DarkGreen, rectangle.Width, rectangle.Height);
            this.middleTexture = Tools.CreateColorTexture(Color.Green, rectangle.Width, rectangle.Height);
            this.deadTexture = Tools.CreateColorTexture(Color.LightGreen, rectangle.Width, rectangle.Height);
        }

        internal void Update(MouseState mouseState)
        {
            int mousePosX = mouseState.Position.X;
            int mousePosY = mouseState.Position.Y;

            if (rectangle.Intersects(new Rectangle(mousePosX, mousePosY, 1, 1)))
            {
                isAlive = State.Alive;
            }
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            if (isAlive == State.Alive)
            {
                spriteBatch.Draw(aliveTexture, rectangle, Color.White);
            }
            else if(isAlive == State.Middle)
            {
                spriteBatch.Draw(middleTexture, rectangle, Color.White);
            }
            else if (isAlive == State.Dead)
            {
                spriteBatch.Draw(deadTexture, rectangle, Color.White);
            }
        }

        internal void Evolve()
        {
            this.isAlive = this.nextGenerationState;
        }

        internal void SetNeighbors(Cell[,] cells, int row, int col)
        {
            neighbors = new List<Cell>();

            // Get surrounding cells
            Cell celTopL, celTopC, celTopR, celMiddleL, /*celMiddleC,*/ celMiddleR, celDownL, celDownC, celDownR;

            try { celTopL = cells[row - 1, col - 1]; } catch { celTopL = null; }
            try { celTopC = cells[row - 1, col]; } catch { celTopC = null; }
            try { celTopR = cells[row - 1, col + 1]; } catch { celTopR = null; }

            try { celMiddleL = cells[row, col - 1]; } catch { celMiddleL = null; }
            //try { celMiddleC = cells[row, col]; } catch { celMiddleC = null; }
            try { celMiddleR = cells[row, col + 1]; } catch { celMiddleR = null; }

            try { celDownL = cells[row + 1, col - 1]; } catch { celDownL = null; }
            try { celDownC = cells[row + 1, col]; } catch { celDownC = null; }
            try { celDownR = cells[row + 1, col + 1]; } catch { celDownR = null; }

            Cell[] surroundingCells = new Cell[] { celTopL, celTopC, celTopR, celMiddleL, /*celMiddleC,*/ celMiddleR, celDownL, celDownC, celDownR };

            // Filter null
            neighbors = surroundingCells
                .Where(x => x != null)
                .ToList();
        }

    }
}
