using iQuest.VendingMachine.DataAccess;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace VendingMachine.UnitTest
{
    public class LookUnitTests
    {
        private Mock<IProductRepository> _productRepository;

        private Mock<IShelfView> _shelfView;
         
        public LookUnitTests()
        {
            _productRepository = new Mock<IProductRepository>();

            _shelfView = new Mock<IShelfView>();
        }

        [Fact]
        public void LookUseCase_WhenInitializingTheUseCase_NameIsCorrect()
        {
            var _lookUseCase = new LookUseCase( _shelfView.Object, _productRepository.Object);
            string expectedName = "look";

            Assert.Equal(expectedName,_lookUseCase.Name);
        }

        [Fact]
        public void LookUseCase_WhenInitializingTheUseCase_DescriptionIsCorrect()
        {
            var _lookUseCase = new LookUseCase(_shelfView.Object, _productRepository.Object);
            string expectedDescription = "Look at the products";

            Assert.Equal(expectedDescription,_lookUseCase.Description);
        }

        [Fact]
        public void LookUseCase_WhenInitializingTheUseCase_CanExecuteIsTrue()
        {
            var _lookUseCase = new LookUseCase(_shelfView.Object, _productRepository.Object);

            Assert.True(_lookUseCase.CanExecute);
        }

        [Fact]
        public void LookUseCase_WhenProductRepositoryIsNull_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new LookUseCase(_shelfView.Object, null));
        }
        [Fact]
        public void LookUseCase_WhenShelViewIsNull_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new LookUseCase(null, _productRepository.Object));
        }

        [Fact]
        public void LookUseCase_WhenExecuted_GetAllIsExecutedOnce()
        {
            var _lookUseCase = new LookUseCase(_shelfView.Object, _productRepository.Object);
            List<Product> product = new List<Product>()
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
                Quantity=10
            },
            };
            _productRepository.Setup(b => b.GetAll()).Returns(product);

            _lookUseCase.Execute();

            _productRepository.Verify(_productRepository => _productRepository.GetAll(),Times.Once);
        }

        [Fact]
        public void LookUseCase_WhenExecuted_DisplayProductIsExecutedOnce()
        {
            var _lookUseCase = new LookUseCase(_shelfView.Object, _productRepository.Object);
            List<Product> product = new List<Product>()
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
                Quantity=10
            },
            };
            _productRepository.Setup(b => b.GetAll()).Returns(product);
            _shelfView.Setup(x => x.DisplayProducts(product));

            _lookUseCase.Execute();

            _shelfView.Verify(_shelfView => _shelfView.DisplayProducts(product), Times.Once); 
        }

    }
}
