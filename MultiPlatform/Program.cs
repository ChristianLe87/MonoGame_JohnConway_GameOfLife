using System;
using Shared;

namespace MultiPlatform
{
    class MainClass
    {
        public static void Main()
        {
            using (var game = new MyGame())
            {
                game.Run();
            }
        }
    }
}
