using iQuest.VendingMachine.Exeptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PaymentType;
using System;
using System.Collections.Generic;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class BuyView : DisplayBase, IBuyView
    {
        public string RequestProduct()
        {
            Display("Enter the column where the product you want is located: ", ConsoleColor.Yellow);

            string column = Console.ReadLine();

            if (string.IsNullOrEmpty(column))
            {
                throw new CancelExeption();
            }  
            return column;
        }
        public void DisplayProduct(string name)
        {
            DisplayLine(name, ConsoleColor.Cyan);
        }
        public int AskForPaymentMethod(IEnumerable<PaymentMethod> paymentMethods)
        {
            const string displayMessage = "Choose payment method's id.";
            const string paymentMethodDisplay = "Payment method:";
            bool checkPaymentMethod = false;
            DisplayLine(displayMessage, ConsoleColor.Blue);
            foreach (var paymentMethod in paymentMethods)
            {
                DisplayLine($"{paymentMethod.Id} {paymentMethodDisplay} {paymentMethod.Name}", ConsoleColor.DarkYellow);
            }
            string input = Console.ReadLine();
            while (checkPaymentMethod == false)
            {
                if (input == "1" || input == "2")
                {
                    checkPaymentMethod = true;
                }
                else
                {
                    DisplayLine($"{input} ID is invalid", ConsoleColor.Green);
                    input = Console.ReadLine();
                }
             }
            if (string.IsNullOrEmpty(input))
            {
                throw new CancelExeption();
            }
             return Convert.ToInt32(input); 
        }
    }
}
