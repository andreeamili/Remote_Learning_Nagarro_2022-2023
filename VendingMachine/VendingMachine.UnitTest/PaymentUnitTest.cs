using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Exeptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PaymentType;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace VendingMachine.UnitTest
{
    public class PaymentUnitTest
    {

        private Mock<IProductRepository> _productRepository;

        private Mock<IBuyView> _buyView;

        private Mock<IAuthenticationService> _authentificationService;

        private Mock<List<IPaymentAlgorithm>> _paymentAlgorithm;

        public PaymentUnitTest()
        {
            _productRepository = new Mock<IProductRepository>();
            _buyView = new Mock<IBuyView>();
            _authentificationService = new Mock<IAuthenticationService>();
            _paymentAlgorithm= new Mock<List<IPaymentAlgorithm>>();
        }

        [Fact] 
        public void PaymentUseCase_WhenInitializingTheUseCase_NameIsCorrect()
        {
            var _paymentUseCase = new PaymentUseCase(_authentificationService.Object, _buyView.Object, _productRepository.Object, _paymentAlgorithm.Object);
            string expectedName = "pay";

            Assert.Equal(expectedName, _paymentUseCase.Name);
        }

        [Fact]
        public void PaymentUseCase_WhenInitializingTheUseCase_DescriptionIsCorrect()
        {
            var _paymentUseCase = new PaymentUseCase(_authentificationService.Object, _buyView.Object, _productRepository.Object, _paymentAlgorithm.Object);
            string expectedDescription = "Choose payment method";

            Assert.Equal(expectedDescription, _paymentUseCase.Description);
        }

        [Theory]
        [InlineData(true)]
        public void PaymentUseCase_WhenInitializingTheUseCase_CanExecuteIsFalse(bool isUserAuthenticated)
        {
            _authentificationService.Setup(permission => permission.IsUserAuthenticated).Returns(isUserAuthenticated);
            var _paymentUseCase = new PaymentUseCase(_authentificationService.Object, _buyView.Object, _productRepository.Object, _paymentAlgorithm.Object);

            Assert.NotEqual(isUserAuthenticated, _paymentUseCase.CanExecute);
        }


        [Fact]
        public void PaymentUseCase_WhenAuthenticationServiceIsNull_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new PaymentUseCase(null, _buyView.Object, _productRepository.Object, _paymentAlgorithm.Object));
        }

        [Fact]
        public void PaymentUseCase_WhenBuyViewIsNull_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new PaymentUseCase(_authentificationService.Object, null, _productRepository.Object, _paymentAlgorithm.Object));
        }

        [Fact]
        public void PAymentUseCase_WhenProductRepositoryIsNull_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new PaymentUseCase(_authentificationService.Object, _buyView.Object, null, _paymentAlgorithm.Object));
        }

        [Fact]
        public void PAymentUseCase_WhenaymentAlgorithmIsNull_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new PaymentUseCase(_authentificationService.Object, _buyView.Object, _productRepository.Object, null));
        }

        [Fact]
        public void PaymentUseCase_WhenAskForPaymentMethodInputIsNullOrEmpty_CancelExeption()
        {
            var _paymentUseCase = new PaymentUseCase(_authentificationService.Object, _buyView.Object, _productRepository.Object, _paymentAlgorithm.Object);

            _buyView.Setup(a => a.AskForPaymentMethod(new List<PaymentMethod>())).Throws(new CancelExeption());

            Assert.Throws<CancelExeption>(() => _buyView.Object.AskForPaymentMethod(new List<PaymentMethod>()));
        }

        [Fact]
        public void Execute_WhenAskForPaymentMethodInputIsInvalid_InvalidColumnIdException()
        {
            var _paymentUseCase = new PaymentUseCase(_authentificationService.Object, _buyView.Object, _productRepository.Object, _paymentAlgorithm.Object);

            _buyView.Setup(a => a.AskForPaymentMethod(new List<PaymentMethod>())).Throws(new InvalidColumnIdException());

            Assert.Throws<InvalidColumnIdException>(() => _buyView.Object.AskForPaymentMethod(new List<PaymentMethod>()));
        }

        [Fact]
        public void PaymentUseCase_WhenAllExecuted_AskForPaymentMethodExecuted()
        {
            int result=1;
            int expectesResult=1;
            var _paymentUseCase = new PaymentUseCase(_authentificationService.Object, _buyView.Object, _productRepository.Object, _paymentAlgorithm.Object);

            _buyView.Setup(a => a.AskForPaymentMethod(new List<PaymentMethod>()
                {   new PaymentMethod { Name = "Cashe", Id=1 },
                })).Returns(result);    
            _paymentUseCase.Execute(4.5m);

            Assert.Equal(expectesResult, result);
        }

    }
}
