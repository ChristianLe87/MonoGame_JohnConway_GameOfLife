using System;
using Shared;

namespace MultiPlatform
{
    class Program
    {
        static void Main()
        {
            using (var game = new MyGame())
            {
                game.Run();
            }
        }
    }
}
