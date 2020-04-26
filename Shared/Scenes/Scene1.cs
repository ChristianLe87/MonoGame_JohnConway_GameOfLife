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

        public Scene1(ContentManager content)
        {
            for (var row = 0; row < 50; row++)
            {
                for (var col = 0; col < 50; col++)
                {
                    cells[row, col] = new Cell(new Rectangle(col * 10, row * 10, 10, 10), false, Color.Green, Color.Brown);
                }
            }

            cells[20, 10].isAlive = true;
            cells[20, 11].isAlive = true;
            cells[20, 12].isAlive = true;
        }

        public void Update()
        {
            foreach (var cell in cells)
            {
                cell.Update();
            }


            // Get surrounding cells
            Cell[,] newCells = new Cell[50, 50];

            for (var row = 0; row < 50; row++)
            {
                for (var col = 0; col < 50; col++)
                {

                    Cell celTopL, celTopC, celTopR, celMiddleL, celMiddleC, celMiddleR, celDownL, celDownC, celDownR;

                    try { celTopL = cells[row - 1, col - 1]; } catch { celTopL = null; }
                    try { celTopC = cells[row - 1, col]; } catch { celTopC = null; }
                    try { celTopR = cells[row - 1, col + 1]; } catch { celTopR = null; }

                    try { celMiddleL = cells[row, col - 1]; } catch { celMiddleL = null; }
                    try { celMiddleC = cells[row, col]; } catch { celMiddleC = null; }
                    try { celMiddleR = cells[row, col + 1]; } catch { celMiddleR = null; }

                    try { celDownL = cells[row + 1, col - 1]; } catch { celDownL = null; }
                    try { celDownC = cells[row + 1, col]; } catch { celDownC = null; }
                    try { celDownR = cells[row + 1, col + 1]; } catch { celDownR = null; }

                    Cell[] surroundingCells = new Cell[] { celTopL, celTopC, celTopR, celMiddleL, celMiddleC, celMiddleR, celDownL, celDownC, celDownR };

                    // check if new cell will be alive
                    var aliveCells = surroundingCells.Where(x => x != null).Where(x=>x.isAlive == true).ToArray();

                    if (cells[row, col].isAlive == false && aliveCells.Count() == 3)
                    {
                        newCells[row, col] = cells[row, col];
                        newCells[row, col].isAlive = true;
                    }
                    else if(cells[row, col].isAlive == true && ((aliveCells.Count() == 2 || aliveCells.Count() == 3)))
                    {
                        newCells[row, col] = cells[row, col];
                        newCells[row, col].isAlive = false;

                    }
                }
            }

            cells = newCells;




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
