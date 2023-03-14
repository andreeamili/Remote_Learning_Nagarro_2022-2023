using iQuest.VendingMachine.DataAccess;
using iQuest.VendingMachine.Exeptions;
using iQuest.VendingMachine.Interfaces;
using System;

namespace iQuest.VendingMachine.UseCases
{

    internal class BuyUseCase : IUseCase
    {
        private readonly IProductRepository productRepository;

        private readonly IBuyView buyView;

        private readonly IAuthenticationService authenticationService;

        private readonly IPaymentUseCase paymentUseCase;

        public string Name => "buy";

        public string Description => "Press the column where is your product";

        public bool CanExecute => !authenticationService.IsUserAuthenticated;


        public BuyUseCase(IAuthenticationService authenticationService, IBuyView buyView, IProductRepository productRepository, IPaymentUseCase paymentUseCase)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));

            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));

            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));

            this.paymentUseCase = paymentUseCase ?? throw new ArgumentNullException(nameof(paymentUseCase));
        }
        public void Execute()
        {
            string productId = buyView.RequestProduct();

            int productIdInt = int.Parse(productId);

            Product requestedProduct = productRepository.GetByColumn(productIdInt);

            if(requestedProduct == null)
            {
                throw new InvalidColumnIdException();
            }
            if (requestedProduct.Quantity <= 0)
            {
                throw new OutOfStockException(requestedProduct.Name);
            }

            buyView.DisplayProduct(requestedProduct.Name);

            paymentUseCase.Execute(requestedProduct.Price);

            productRepository.DecrementPtoduct(requestedProduct); 

            Console.WriteLine();
            Console.WriteLine("You have just purchased the product!");
        }
    }
}