using iQuest.VendingMachine.Exeptions;
using iQuest.VendingMachine.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.DataAccess
{
    internal class ProductRepository : IProductRepository
    {
        private static List<Product> _products = new List<Product>()
            {
             new Product
             {
                 ColumnId=1,
                 Name="Chocolate",
                 Price=4.5m,
                 Quantity=6
             },
            new Product
            {
                ColumnId=2,
                Name="Chips",
                Price=3.5m,
                Quantity=0
            },
            new Product
            {
                ColumnId=3,
                Name ="Cookies",
                Price=2.5m,
                Quantity=4 },
            new Product
            {
                ColumnId=4,
                Name="Sandwich",
                Price=5.5m,
                Quantity=0
            },
            new Product
            {
                ColumnId=6,
                Name="Soda",
                Price=3m,
                Quantity=5
            },
            new Product
            {
                ColumnId=8,
                Name= "Tea",
                Price= 1.5m,
                Quantity= 11
            },
            };
        public IEnumerable<Product> GetAll()
        {
            return new List<Product>(_products);
        }

        public Product GetByColumn(int column)
        {

            foreach (Product product in _products)
            {

                if (product.ColumnId == column)
                {
                    return product;
                }
            }
            return null;
        }

        public void UpdateProduct(Product newProduct, int columnId, int numberOfProducts)
        {
            if (numberOfProducts != 0)
            {
                foreach (Product product in _products)
                {
                    if (product.ColumnId == columnId)
                    {
                        product.Quantity += numberOfProducts;
                        Console.WriteLine();
                        Console.WriteLine("The product was supplied");
                        return;
                    }
                }
            }
            _products.Add(newProduct);
            Console.WriteLine();
            Console.WriteLine("The product was added");
        }

        public void DecrementPtoduct(Product requestProduct)
        {
            foreach(Product product in _products )
            {
                if(product.Name == requestProduct.Name)
                {
                    product.Quantity--;
                }
            }
        }
    }
}
