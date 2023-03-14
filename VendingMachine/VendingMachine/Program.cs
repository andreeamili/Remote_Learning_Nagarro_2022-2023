using iQuest.VendingMachine.DataAccess;
using System;
using System.Data.SQLite;

namespace iQuest.VendingMachine
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                //ProductRepositoryDB productRepositoryDB = new ProductRepositoryDB();
               // productRepositoryDB.InsertTheValue();
                Bootstrapper bootstrapper = new Bootstrapper();
                bootstrapper.Run();
            }
            catch (Exception ex)
            {
                DisplayError(ex);
                Pause();
            }
        }

        private static void DisplayError(Exception ex)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex);
            Console.ForegroundColor = oldColor;
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