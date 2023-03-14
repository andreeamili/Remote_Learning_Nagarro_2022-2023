using iQuest.VendingMachine.DataAccess;
using iQuest.VendingMachine.Exeptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.UseCases;
using Moq;
using System.Diagnostics;

namespace VendingMachine.UnitTest
{
    public class BuyUnitTests
    {
        private Mock<IProductRepository> _productRepository;

        private Mock<IBuyView> _buyView;

        private Mock<IAuthenticationService> _authentificationService;

        private Mock<IPaymentUseCase> _paymentUseCase;

        public BuyUnitTests()
        {
            _productRepository = new Mock<IProductRepository>();
            _productRepository.Setup(x => x.GetByColumn(It.IsAny<int>())).Returns(new Product { Quantity = 1 });

            _buyView = new Mock<IBuyView>();
            _buyView.Setup(x => x.RequestProduct()).Returns(Convert.ToString(int.MaxValue));

            _authentificationService = new Mock<IAuthenticationService>();
            _authentificationService.Setup(permission => permission.IsUserAuthenticated).Returns(false);

            _paymentUseCase = new Mock<IPaymentUseCase>();
        }

        [Fact]
        public void BuyUseCase_WhenInitializingTheUseCase_NameIsCorrect()
        {
            var _buyUseCase = new BuyUseCase(_authentificationService.Object, _buyView.Object, _productRepository.Object, _paymentUseCase.Object);
            string expectedName = "buy";

            Assert.Equal(expectedName, _buyUseCase.Name);
        }

        [Fact]
        public void BuyUseCase_WhenInitializingTheUseCase_DescriptionIsCorrect()
        {
            var _buyUseCase = new BuyUseCase(_authentificationService.Object, _buyView.Object, _productRepository.Object, _paymentUseCase.Object);
            string expectedDescription = "Press the column where is your product";

            Assert.Equal(expectedDescription, _buyUseCase.Description);
        }

        [Theory]
        [InlineData(false)]
        public void BuyUseCase_WhenInitializingTheUseCase_CanExecuteIsFalse(bool isUserAuthenticated)
        {
            _authentificationService.Setup(permission => permission.IsUserAuthenticated).Returns(isUserAuthenticated);
            var _buyUseCase = new BuyUseCase(_authentificationService.Object, _buyView.Object, _productRepository.Object, _paymentUseCase.Object);

            Assert.NotEqual(isUserAuthenticated, _buyUseCase.CanExecute);
        }

        [Fact]
        public void BuyUseCase_WhenAuthenticationServiceIsNull_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new BuyUseCase(null, _buyView.Object, _productRepository.Object, _paymentUseCase.Object));
        }

        [Fact]
        public void BuyUseCase_WhenBuyViewIsNull_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new BuyUseCase(_authentificationService.Object, null, _productRepository.Object, _paymentUseCase.Object));
        }

        [Fact]
        public void BuyUseCase_WhenProductRepositoryIsNull_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new BuyUseCase(_authentificationService.Object, _buyView.Object, null, _paymentUseCase.Object));
        }

        [Fact]
        public void BuyUseCase_WhenPaymentUSeCaseIsNull_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new BuyUseCase(_authentificationService.Object, _buyView.Object, _productRepository.Object, null));
        }

        [Fact]
        public void Execute_WhenIsNullOrEmpty_ThenCancelExceptionIsCalled()
        {
            var _buyUseCase = new BuyUseCase(_authentificationService.Object, _buyView.Object, _productRepository.Object, _paymentUseCase.Object);

            _buyView.Setup(buyView => buyView.RequestProduct()).Throws(new CancelExeption());

            Assert.Throws<CancelExeption>(() => _buyUseCase.Execute());
        }

        [Fact]
        public void Execute_WhenIsNotInt_ThenInvalidColumnIdException()
        {

            var _buyUseCase = new BuyUseCase(_authentificationService.Object, _buyView.Object, _productRepository.Object, _paymentUseCase.Object);

            _buyView.Setup(buyView => buyView.RequestProduct()).Throws(new FormatException());

            Assert.Throws<FormatException>(() => _buyUseCase.Execute());

        }

        [Fact]
        public void Execute_WhenIsOutOfStock_ThenOutOfStockExceptionIsCalled()
        {
            var _buyUseCase = new BuyUseCase(_authentificationService.Object, _buyView.Object, _productRepository.Object, _paymentUseCase.Object);

            _buyView.Setup(buyView => buyView.RequestProduct()).Returns("1");
            _productRepository.Setup(productRepository => productRepository.GetByColumn(It.Is<int>(i => i == 1))).Throws(new OutOfStockException("Chocolate"));

            Assert.Throws<OutOfStockException>(() => _buyUseCase.Execute());

        }

        [Fact]
        public void HavingColumnId_WhenColumnIdIsNotValid_ThenInvalidColumnIdException()
        {
            _buyView.Setup(buyView => buyView.RequestProduct()).Throws(new InvalidColumnIdException());

            Assert.Throws<InvalidColumnIdException>(() => _buyView.Object.RequestProduct());
        }

        [Fact]
        public void BuyUseCase_WhenAllExecuted_GetByColumnIsExecutedOnce()
        {
            const int columnId = 1;
            var _buyUseCase = new BuyUseCase(_authentificationService.Object, _buyView.Object, _productRepository.Object, _paymentUseCase.Object);

            _buyView.Setup(x => x.RequestProduct()).Returns(Convert.ToString(columnId));
            _buyUseCase.Execute();

            _productRepository.Verify(_productRepository => _productRepository.GetByColumn(columnId), Times.Once);
        }
        [Fact]
        public void Execute_Always_CallsRequestProduct()
        {
            var _buyUseCase = new BuyUseCase(_authentificationService.Object, _buyView.Object, _productRepository.Object, _paymentUseCase.Object);

            _buyUseCase.Execute();

            _buyView.Verify(_buyView => _buyView.RequestProduct(), Times.Once);

        }
        [Fact]
        public void Execute_Always_CallsExecute()
        {
            Product requestProduct;
            var _buyUseCase = new BuyUseCase(_authentificationService.Object, _buyView.Object, _productRepository.Object, _paymentUseCase.Object);
            
            _buyView.Setup(x => x.RequestProduct()).Returns(Convert.ToString(1));
            requestProduct=_productRepository.Object.GetByColumn(1);
            _buyUseCase.Execute();

            _paymentUseCase.Verify(_paymentUseCase => _paymentUseCase.Execute(requestProduct.Price), Times.Once);

        }
    }
}
