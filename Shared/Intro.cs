using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    internal class Intro : IScene
    {
        Rectangle rectangle;
        Texture2D texture;

        long startTime;


        public Intro()
        {
            this.rectangle = new Rectangle(0, 0, 500, 500);
            this.texture = Tools.CreateColorTexture(Color.Black, 500, 500);
            this.startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }

        public void Update(GameTime gameTime)
        {
            // wait 3 seconds
            if (gameTime.TotalGameTime.Seconds > 3)
            {
                MyGame.actualScene = WK.Scene.Menu;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }

    }
}
