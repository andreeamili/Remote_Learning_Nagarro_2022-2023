using iQuest.BooksAndNews.Application.Publications;
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
        private readonly ILog Log;

        private readonly string Name;

        private PrintingOffice PrintingOffice;

        public BookLover(string name, PrintingOffice printingOffice, ILog log)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            PrintingOffice = printingOffice ?? throw new ArgumentNullException(nameof(printingOffice));
            PrintingOffice.BookEvent += OnBookCreated; 
            Log = log ?? throw new ArgumentNullException(nameof(log));
        }
        public void OnBookCreated(Book book)
        {
            Log.WriteInfo(Name + " was informed about the book");
        }
    }
}