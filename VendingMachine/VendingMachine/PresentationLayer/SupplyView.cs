using iQuest.VendingMachine.DataAccess;
using iQuest.VendingMachine.Exeptions;
using iQuest.VendingMachine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class SupplyView : DisplayBase, ISupplyView
    {
        public int RequestProductID()
        {
            Console.WriteLine();
            Display("Insert ptoduct ID that you want to add: ", ConsoleColor.Green);

            string columnId = Console.ReadLine();

            if(string.IsNullOrEmpty(columnId))
            {
                throw new CancelExeption();
            }
            return Convert.ToInt32(columnId);
        }
        public Product RequestProduct()
        {
            Product newProduct = new Product();
            DisplayLine("Insert the ColumnId  of the new product", ConsoleColor.DarkYellow);
          
            string columnId = Console.ReadLine();
            if (string.IsNullOrEmpty(columnId))
            {
                throw new CancelExeption();
            }
            newProduct.ColumnId=Convert.ToInt32(columnId);

            DisplayLine("Insert the name  of the new product", ConsoleColor.DarkYellow);
            string name=Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                throw new CancelExeption();
            }
            newProduct.Name = name;

            DisplayLine("Insert the quantity  of the new product", ConsoleColor.DarkYellow);
            string quantity = Console.ReadLine();
            if (string.IsNullOrEmpty(quantity))
            {
                throw new CancelExeption();
            }
            newProduct.Quantity = Convert.ToInt32(quantity);

            DisplayLine("Insert the price  of the new product", ConsoleColor.DarkYellow);
            string price = Console.ReadLine();
            if (string.IsNullOrEmpty(price))
            {
                throw new CancelExeption();
            }
            newProduct.Price = Convert.ToDecimal(price);

            return newProduct;
        }
        public int RequestNumberOfProducts()
        {
            Display("Insert the number of products you want to add: ", ConsoleColor.Green);

            string numberOfProducts = Console.ReadLine();

            if (string.IsNullOrEmpty(numberOfProducts))
            {
                throw new CancelExeption();
            }
            return Convert.ToInt32(numberOfProducts);
        }

        public void ViewTheMissingProducts()
        {
            bool checkIfAllProsuctsAreFull = true;
            IProductRepository productRepository = new ProductRepository();
            IEnumerable<Product> products= productRepository.GetAll();

            Display("The products that are out of stock are ", ConsoleColor.DarkRed);

            foreach (Product product in products)
            {
                if (product.Quantity == 0)
                {
                    Console.WriteLine();
                    Display(product.ColumnId + " " + product.Name, ConsoleColor.DarkRed);
                    checkIfAllProsuctsAreFull = false;
                }
            }

            if(checkIfAllProsuctsAreFull==true)
            {
                Display("No product is out of stock", ConsoleColor.DarkRed);
            }
        }
    }
}
