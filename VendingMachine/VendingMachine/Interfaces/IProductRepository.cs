using iQuest.VendingMachine.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.Interfaces
{
    internal interface IProductRepository
    {
        public IEnumerable<Product> GetAll();

        public Product GetByColumn(int column);

        public void DecrementPtoduct(Product requestProduct); 

        public void UpdateProduct(Product newProduct, int ColumnId,int numberOfProducts);
    }
}
