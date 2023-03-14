using iQuest.VendingMachine.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.Interfaces
{
    internal interface ISupplyView
    {
        public int RequestProductID();

        public int RequestNumberOfProducts();

        public Product RequestProduct();
        public void ViewTheMissingProducts();

    }
}
