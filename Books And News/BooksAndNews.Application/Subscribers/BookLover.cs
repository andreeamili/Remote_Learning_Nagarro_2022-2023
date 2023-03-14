using iQuest.BooksAndNews.Application.Publishers;
using System;

namespace iQuest.BooksAndNews.Application.Subscribers
{
    // todo: This class must be implemented.

    /// <summary>
    /// This is a subscriber that is interested to receive notification whenever a book
    /// is printed.
    ///
    /// Subscribe to the printing office and log each book that was printed.
    /// </summary>
    public class BookLover
    {
        private PrintingOffice PrintingOffice;

        private ILog Log;

        private string Name;

        public BookLover(string name, PrintingOffice printingOffice, ILog log)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            PrintingOffice = printingOffice ?? throw new ArgumentNullException(nameof(printingOffice));
            PrintingOffice.createdBookEventHandler += OnBookCreated;
            Log = log ?? throw new ArgumentNullException(nameof(log));
        }
        public void OnBookCreated(object sender, CustomEvent e)
        {
            Log.WriteInfo(Name + " was informed that the book was printed.");
        }
    }
}