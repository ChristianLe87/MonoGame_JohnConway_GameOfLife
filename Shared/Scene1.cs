using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Scene1 : IScene
    {
        Cell[,] cell = new Cell[50, 50];
        public Scene1(ContentManager content)
        {
            for(var row= 0;row<50; row++)
            {
                for (var col = 0; col < 50; col++)
                {
                    cell[row, col] = new Cell(new Vector2(col * 10, row * 10), true, Color.Green, Color.Brown);
                }
            }
        }

        public void Update()
        {
            //cell.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(var i in cell)
            {
                if(i != null)
                    i.Draw(spriteBatch);
            }
        }
    }
}
