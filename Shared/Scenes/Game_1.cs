using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Game_1 : IScene
    {
        Cell[,] cells;
        float timeCount = 0f;
        Button GoToMenuButton;

        public void Initialize()
        {
            this.GoToMenuButton = new Button(
                                            rectangle: new Rectangle(5, 5, 70, 30),
                                            text: "Menu",
                                            defaultTexture: Tools.CreateColorTexture(MyGame.graphicsDeviceManager.GraphicsDevice, Color.Gray, 10, 10),
                                            mouseOverTexture: Tools.CreateColorTexture(MyGame.graphicsDeviceManager.GraphicsDevice, Color.DarkGray, 10, 10),
                                            spriteFont: Tools.GetFont(MyGame.contentManager, WK.Font.Arial_10),
                                            fontColor: Color.Black
                                            );



            int numRows = WK.Level.dis1.GetLength(0);
            int numColumn = WK.Level.dis1.GetLength(1);


            cells = new Cell[numRows, numColumn];

            // define each cell
            for (var row = 0; row < numRows; row++)
            {
                for (var col = 0; col < numColumn; col++)
                {
                    if (WK.Level.dis1[row, col] == ' ')
                    {
                        cells[row, col] = new Cell(new Rectangle(col * 10, row * 10, 10, 10), State.Dead);
                    }
                    else if (WK.Level.dis1[row, col] == 'x')
                    {
                        cells[row, col] = new Cell(new Rectangle(col * 10, row * 10, 10, 10), State.Alive);
                    }
                }
            }

            // Get neighbors
            for (var row = 0; row < numRows; row++)
            {
                for (var col = 0; col < numColumn; col++)
                {
                    cells[row, col].SetNeighbors(cells, row, col);
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            GoToMenuButton.Update(GoToMenuButtonLogic);

            MouseState mouseState = Mouse.GetState();
            if (mouseState.RightButton == ButtonState.Pressed || mouseState.LeftButton == ButtonState.Pressed)
            {
                foreach (var cell in cells)
                {
                    cell.Update(mouseState);
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
                    foreach (var cell in cells)
                    {
                        CellLogic_1(cell);
                    }

                    // apply evolution
                    foreach (var cell in cells)
                    {
                        cell.Evolve();
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var cel in cells) cel.Draw(spriteBatch);

            GoToMenuButton.Draw(spriteBatch);
        }

        public void GoToMenuButtonLogic()
        {
            Console.WriteLine("Menu");
            MyGame.actualScene = WK.Scene.Menu;
            MyGame.scenes[MyGame.actualScene].Initialize();
        }

        private void CellLogic_1(Cell cell)
        {
            int nAliveCells = cell.neighbors.Where(x => x.isAlive == State.Alive).Count();

            // Any live cell with fewer than two live neighbours dies, as if by underpopulation.
            if (cell.isAlive == State.Alive && nAliveCells < 2)
            {
                cell.nextGenerationState = State.Dead;
            }

            // Any live cell with two or three live neighbours lives on to the next generation.
            if (cell.isAlive == State.Alive && nAliveCells == 2)
            {
                cell.nextGenerationState = State.Alive;
            }
            else if (cell.isAlive == State.Alive && nAliveCells == 3)
            {
                cell.nextGenerationState = State.Alive;
            }

            // Any live cell with more than three live neighbours dies, as if by overpopulation.
            if (cell.isAlive == State.Alive && nAliveCells > 3)
            {
                cell.nextGenerationState = State.Dead;
            }

            // Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
            if (cell.isAlive == State.Dead && nAliveCells == 3)
            {
                cell.nextGenerationState = State.Alive;
            }
        }
    }
}
