using iQuest.VendingMachine.PresentationLayer;
using System;
using System.Collections.Generic;
using iQuest.VendingMachine.DataAccess;
using iQuest.VendingMachine.Interfaces;

namespace iQuest.VendingMachine.UseCases
{
    internal class LookUseCase : IUseCase
    {
        private IShelfView shelfView ;
        private IProductRepository productRepository ;
        public string Name => "look";
        public string Description => "Look at the products";
        public  bool CanExecute => true;
        public LookUseCase(IShelfView shelfView, IProductRepository productRepository)
        {
            this.shelfView = shelfView ?? throw new ArgumentNullException(nameof(shelfView));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository)); ;
        }

        public void Execute()
        {
            IEnumerable<Product> productInitial;
            List<Product> productFinal=new List<Product>();
            productInitial = productRepository.GetAll();
            foreach(Product products in productInitial)
            {
                if (products.Quantity > 0)
                    productFinal.Add(products);
            }
            shelfView.DisplayProducts((List<Product>)productFinal);
        }
        
    }
}
