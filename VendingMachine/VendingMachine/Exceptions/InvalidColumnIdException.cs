using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.Exeptions
{
    public class InvalidColumnIdException : Exception
    {
        private const string exceptionMessage = "This ID is invalid!";

        public InvalidColumnIdException() : base(exceptionMessage)
        {
        }
        
    }
}
