using System;
using iQuest.GrandCircus.CircusModel;
using iQuest.GrandCircus.Presentation;

namespace iQuest.GrandCircus
{
    internal class Program
    {
        private static void Main()
        {
            Arena arena = new Arena();

            Circus circus = new Circus(arena);
            circus.Perform();

            Pause();
        }

        private static void Pause()
        {
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
            Console.WriteLine();
        }
    }
}