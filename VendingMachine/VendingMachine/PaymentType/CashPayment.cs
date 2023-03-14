using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PresentationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.PaymentType
{
    internal class CashPayment : IPaymentAlgorithm
    {
        public string Name => "Cash";

        public void Run(decimal price)
        {
            CashPaymentTerminal cachePaymentTerminal = new CashPaymentTerminal();
            decimal money = Convert.ToDecimal(cachePaymentTerminal.AskForMoney(price));
            if (money > price)
            {
                decimal change = money - price;
                cachePaymentTerminal.GiveBackChange(change);
            }
            else if (money < price)
            {
                throw new NotEnoughMoneyException();
            }
        }
    }
}
