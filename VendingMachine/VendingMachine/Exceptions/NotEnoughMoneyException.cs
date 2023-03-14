using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.Exceptions
{
    internal class NotEnoughMoneyException : Exception
    {
        private const string exceptionMessage = "You don't have enough money";

        public NotEnoughMoneyException():base(exceptionMessage)
        {

        }
    }

}
