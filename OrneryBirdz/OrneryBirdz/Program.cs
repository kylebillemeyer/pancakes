using System;

namespace OrneryBirdz
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (OrneryBirdzGame game = new OrneryBirdzGame())
            {
                game.Run();
            }
        }
    }
#endif
}

