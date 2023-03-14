using iQuest.VendingMachine.DataAccess;
using System.Collections.Generic;

namespace iQuest.VendingMachine.Interfaces
{
    internal interface IShelfView
    {
        public void DisplayProducts(List<Product> products);
    }
}
