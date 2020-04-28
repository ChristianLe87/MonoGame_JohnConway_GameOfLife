using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Scene1 : IScene
    {
        Cell[,] cells = new Cell[50, 50];
        float timeCount = 0f;

        public Scene1(ContentManager content)
        {
            for (var row = 0; row < 50; row++)
            {
                for (var col = 0; col < 50; col++)
                {
                    if(WK.Level.dis1[row, col] == ' ')
                    {
                        cells[row, col] = new Cell(new Rectangle(col * 10, row * 10, 10, 10), false);
                    }
                    else if(WK.Level.dis1[row, col] == 'x')
                    {
                        cells[row, col] = new Cell(new Rectangle(col * 10, row * 10, 10, 10), true);
                    }                    
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.P))
            {
                foreach (var cell in cells)
                {
                    cell.Update();
                }
            }
            else
            {
                if (timeCount < 100f) // elapsed milliseconds
                {
                    timeCount += gameTime.ElapsedGameTime.Milliseconds;
                }
                else
                {
                    timeCount = 0f;
                    for (var row = 0; row < 50; row++)
                    {
                        for (var col = 0; col < 50; col++)
                        {
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

                            // check if new cell will be alive
                            var nAliveCells = surroundingCells
                                .Where(x => x != null)
                                .Where(x => x.isAlive == true)
                                .ToArray()
                                .Count();

                            // Any live cell with fewer than two live neighbours dies, as if by underpopulation.
                            if (cells[row, col].isAlive == true && nAliveCells < 2)
                            {
                                cells[row, col].nextGenerationState = false;
                            }

                            // Any live cell with two or three live neighbours lives on to the next generation.
                            if (cells[row, col].isAlive == true && nAliveCells == 2)
                            {
                                cells[row, col].nextGenerationState = true;
                            }
                            else if (cells[row, col].isAlive == true && nAliveCells == 3)
                            {
                                cells[row, col].nextGenerationState = true;
                            }

                            // Any live cell with more than three live neighbours dies, as if by overpopulation.
                            if (cells[row, col].isAlive == true && nAliveCells > 3)
                            {
                                cells[row, col].nextGenerationState = false;
                            }

                            // Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
                            if (cells[row, col].isAlive == false && nAliveCells == 3)
                            {
                                cells[row, col].nextGenerationState = true;
                            }
                        }
                    }

                    // apply evolution
                    foreach (var cell in cells) cell.Evolve();
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var cell in cells)
            {
                cell.Draw(spriteBatch);
            }
        }
    }
}
