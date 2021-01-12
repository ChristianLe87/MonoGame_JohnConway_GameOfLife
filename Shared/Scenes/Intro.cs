using System;
using Microsoft.Xna.Framework;
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
            this.texture = Tools.GetTexture(MyGame.graphicsDeviceManager.GraphicsDevice, MyGame.contentManager, WK.Image.Intro_500_500_PNG);
            this.rectangle = new Rectangle(0, 0, texture.Width, texture.Height);

            this.startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }

        public void Update(GameTime gameTime)
        {
            // wait 3 seconds
            if (gameTime.TotalGameTime.Seconds > 2)
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
