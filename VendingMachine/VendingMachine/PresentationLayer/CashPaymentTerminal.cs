using iQuest.VendingMachine.Exeptions;
using System;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class CashPaymentTerminal : DisplayBase
    { 
        public string AskForMoney(decimal price)
        {
            Display($"you have to pay {price}$. Enter cash: ", ConsoleColor.Cyan);
            string money = Console.ReadLine();
            if(string.IsNullOrEmpty(money))
            {
                throw new CancelExeption();
            }
            return money;
        }

        public void GiveBackChange(decimal change)
        {
            Display($"You're change {change}$", ConsoleColor.White);
        }
    }
}
