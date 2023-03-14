using iQuest.VendingMachine.PaymentType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.Interfaces
{
    internal interface IBuyView
    {
        public string RequestProduct();

        public void DisplayProduct(string name);

        public int AskForPaymentMethod(IEnumerable<PaymentMethod> paymentMethods);
    }
}
