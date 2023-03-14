using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PresentationLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.PaymentType
{
    internal class CardPayment : IPaymentAlgorithm
    {
        public string Name => "Card";

        public void Run(decimal price)
        {
            string cardNumber;
            CardPaymentTerminal cardPaymentTerminal = new CardPaymentTerminal();
            cardNumber = cardPaymentTerminal.AskForCardNumber();
            int checkSum = 0, i;
            for (i = cardNumber.Length - 1; i >= 0; i -= 2)
                checkSum += (cardNumber[i] - '0');

            for (i = cardNumber.Length - 2; i >= 0; i -= 2)
            {
                int val = ((cardNumber[i] - '0') * 2);
                while (val > 0)
                {
                    checkSum += (val % 10);
                    val /= 10;
                }
            }
            if (((checkSum % 10) == 0))
            {
                ConsoleColor oldColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("This card in valid");
                Console.ForegroundColor = oldColor;
            }
            else
            {
                throw new InvalidCardException();
            }

        }
    }
}
