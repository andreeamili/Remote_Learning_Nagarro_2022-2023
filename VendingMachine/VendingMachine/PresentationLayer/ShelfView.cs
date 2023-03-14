using System;
using System.Collections.Generic;
using System.Linq;
using iQuest.VendingMachine.DataAccess;
using iQuest.VendingMachine.Interfaces;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class ShelfView :  DisplayBase, IShelfView
    {
        public void DisplayProducts(List<Product> products)
        {
            if (products.Any())
            {
                foreach (DataAccess.Product product in products)
                {
                    DisplayLine($"[{product.ColumnId}] {product.Name} ${product.Price} Quantity: {product.Quantity}", ConsoleColor.Cyan);
                }
                return;
            }
            Display("The VendingMachine is empty", ConsoleColor.Red);
        }

    }
}
