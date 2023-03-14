using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.Exeptions
{
    public class OutOfStockException : Exception
    {
        private const string exceptionMessage = "is out of stock!";

        public OutOfStockException(string message) : base($"{message} {exceptionMessage}") {
        }
    }
}
