
namespace CustomHashTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyHashTable<string> myHashTable = new MyHashTable<string>(4);

            myHashTable.Put("Romania", "Bucharest");
            myHashTable.Put("Romania", "Da");
            myHashTable.Put("Spain", "Madrid");
            myHashTable.Put("France", "Paris");

            Console.WriteLine("myHashTable contains:");
            Console.WriteLine("Romania "+myHashTable.Get("Romania"));
            Console.WriteLine("Spain "+myHashTable.Get("Spain"));
            Console.WriteLine("France "+myHashTable.Get("France"));
            Console.WriteLine();

            try
            {
                Console.WriteLine(myHashTable.Get("Germany"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
            Console.WriteLine(myHashTable.Remove("Romania"));
            Console.WriteLine(myHashTable.Remove("Spain"));
            Console.WriteLine(myHashTable.Remove("France"));
            Console.WriteLine(myHashTable.Remove("Germany"));

            Console.WriteLine();
            Console.WriteLine(myHashTable.Count());
            Console.ReadLine();
        }
    }
}
