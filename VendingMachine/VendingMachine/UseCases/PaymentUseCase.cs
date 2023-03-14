using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PaymentType;
using System.Collections.Generic;
using System;
using iQuest.VendingMachine.Exeptions;

namespace iQuest.VendingMachine.UseCases
{
    internal class PaymentUseCase : IPaymentUseCase
    {
        private IProductRepository productRepository;

        private IBuyView buyView;

        private IAuthenticationService authenticationService;

        private List<IPaymentAlgorithm> paymentAlgorithms;

        public string Name => "pay";

        public string Description => "Choose payment method";

        public bool CanExecute => !authenticationService.IsUserAuthenticated;

        public PaymentUseCase(IAuthenticationService authenticationService, IBuyView buyView, IProductRepository productRepository, List<IPaymentAlgorithm> paymentAlgorithms)
        {
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.paymentAlgorithms = paymentAlgorithms ?? throw new ArgumentNullException(nameof(paymentAlgorithms));
        }

        public void Execute(decimal price)
        {
            int paymentMethod = buyView.AskForPaymentMethod(new List<PaymentMethod>()
                {   new PaymentMethod { Name = "Cash", Id=1 },
                    new PaymentMethod { Name = "Card", Id=2 },
                });
            if (paymentMethod == 1)
            {
                paymentAlgorithms[0].Run(price);
            }
            else if (paymentMethod == 2)
            {
                paymentAlgorithms[1].Run(price);
            }
        }
    }
}
