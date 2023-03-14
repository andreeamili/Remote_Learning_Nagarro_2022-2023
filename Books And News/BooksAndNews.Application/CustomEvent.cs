using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.BooksAndNews.Application
{
    public class CustomEvent : EventArgs
    {
        public string Message { get; set; }

        public CustomEvent(string message)
        {
            Message = message;
        }
    }
}
