using iQuest.BooksAndNews.Application.Publications;
using iQuest.BooksAndNews.Application.Publishers;
using System;

namespace iQuest.BooksAndNews.Application.Subscribers
{
    // todo: This class must be implemented.

    /// <summary>
    /// This is a subscriber that is interested to receive notification whenever news
    /// are printed.
    ///
    /// Subscribe to the printing office and log each news that was printed.
    /// </summary>
    public class NewsHunter
    {
        private PrintingOffice PrintingOffice;

        private ILog Log;

        private string Name;

        public NewsHunter(string name, PrintingOffice printingOffice, ILog log)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            PrintingOffice = printingOffice ?? throw new ArgumentNullException(nameof(printingOffice));
            PrintingOffice.NewspaperEvent += OnNewspaperCreated;
            Log = log ?? throw new ArgumentNullException(nameof(log));
        }
        public void OnNewspaperCreated(Newspaper newspaper)
        {
            Log.WriteInfo(Name + " was informed that the newspaper was printed.");
        }
    }
}