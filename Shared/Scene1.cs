using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Scene1 : IScene
    {
        Cell[,] cell = new Cell[50, 50];
        public Scene1(ContentManager content)
        {
            for (var row = 0; row < 50; row++)
            {
                for (var col = 0; col < 50; col++)
                {
                    cell[row, col] = new Cell(new Rectangle(col * 10, row * 10, 10, 10), true, Color.Green, Color.Brown);
                }
            }
        }

        public void Update()
        {
            foreach (var i in cell)
            {
                i.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var i in cell)
            {
                i.Draw(spriteBatch);
            }
        }
    }
}
