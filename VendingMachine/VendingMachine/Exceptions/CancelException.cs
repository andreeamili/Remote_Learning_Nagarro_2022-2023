using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.Exeptions
{
    internal class CancelExeption : Exception
    {
        private const string exceptionMessage = "You canceled the action!";

        public CancelExeption() : base(exceptionMessage)
        {

        }
        
    }
}
