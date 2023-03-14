using iQuest.VendingMachine.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class CardPaymentTerminal : DisplayBase
    {
        public string AskForCardNumber()
        {
            Display("Insert the number card for the payment.", ConsoleColor.DarkYellow);
            string cardNumber = Console.ReadLine();
            if(string.IsNullOrEmpty(cardNumber))
            {
                throw new TaskCanceledException();
            }
            return cardNumber;
        }
    }
}
