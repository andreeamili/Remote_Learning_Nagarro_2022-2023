using iQuest.VendingMachine.DataAccess;
using iQuest.VendingMachine.Exeptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PresentationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.UseCases
{
    internal class SupplyUseCase : IUseCase
    {
        private readonly IProductRepository productRepository;

        private readonly IBuyView buyView;

        private readonly IAuthenticationService authenticationService;
         
        private readonly ISupplyView supplyView;

        public string Name => "supply";

        public string Description => "Press the column where is the product you want to add";

        public bool CanExecute => this.authenticationService.IsUserAuthenticated;

        public SupplyUseCase(IProductRepository productRepository, IBuyView buyView, IAuthenticationService authenticationService, ISupplyView supplyView)
        {
            this.productRepository = productRepository;
            this.buyView = buyView;
            this.authenticationService = authenticationService;
            this.supplyView = supplyView;
        }

        public void Execute()
        {
            int columnId = 0;
            int numberOfProducts = 0;
            supplyView.ViewTheMissingProducts();
            Console.WriteLine();
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1.Supply an existing one");
            Console.WriteLine("2.Add a new product");

            string chosenAction=Console.ReadLine();
            if (chosenAction == "1")
            {
                 columnId = supplyView.RequestProductID();
                numberOfProducts = supplyView.RequestNumberOfProducts();
                productRepository.UpdateProduct(new Product(),columnId, numberOfProducts);
            }
            else if(chosenAction=="2")
            {
                Product newProduct = new Product();
                newProduct = supplyView.RequestProduct();
                productRepository.UpdateProduct(newProduct,newProduct.ColumnId, 0);
            }
            else
            {
                throw new InvalidColumnIdException();
            }
        }
    }
}
