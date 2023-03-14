using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.Exceptions
{
    internal class InvalidCardException : Exception
    {
        private const string exceptionMessage = "Invalid card number";

        public InvalidCardException():base(exceptionMessage) {}
    }
}
