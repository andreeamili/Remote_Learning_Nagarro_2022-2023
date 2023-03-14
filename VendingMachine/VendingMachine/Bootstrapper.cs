using System;
using System.Collections.Generic;
using System.Linq;
using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.DataAccess;
using iQuest.VendingMachine.Exeptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PaymentType;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.UseCases;

namespace iQuest.VendingMachine
{
    internal class Bootstrapper
    {
        public void Run()
        {
            VendingMachineApplication vendingMachineApplication = BuildApplication();
            vendingMachineApplication.Run();
        }

        private static VendingMachineApplication BuildApplication()
        {
            Console.WriteLine("What do you want?");
            Console.WriteLine("1.Database repository");
            Console.WriteLine("2.In memory repository");
            IProductRepository productRepository;
            string answer = Console.ReadLine();
            MainView mainView = new MainView();
            ILoginView loginView = new LoginView();
            IShelfView shelfView = new ShelfView();
            if (answer == "1")
            { 
                productRepository = new ProductRepositoryDB(); 
            }
            else
            {
                productRepository = new ProductRepository();
            }

            IBuyView buyView = new BuyView();
            IAuthenticationService authenticationService = new AuthenticationService();
            ISupplyView supplyView = new SupplyView();
            List<IPaymentAlgorithm> paymentAlgorithms = new List<IPaymentAlgorithm>()
            {
                new CashPayment(),
                new CardPayment(),
            };
            IPaymentUseCase paymenUseCase = new PaymentUseCase(authenticationService, buyView, productRepository, paymentAlgorithms);

            List<IUseCase> useCases = new List<IUseCase>
            {
                new LoginUseCase(authenticationService, loginView),
                new LogoutUseCase(authenticationService),
                new LookUseCase(shelfView,productRepository),
                new BuyUseCase( authenticationService, buyView,productRepository, paymenUseCase),
                new SupplyUseCase(productRepository, buyView,  authenticationService,supplyView), 
            };

            return new VendingMachineApplication(useCases, mainView);
        }
    }
}