using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.DataAccess;
using iQuest.VendingMachine.Exeptions;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.UseCases;
using Moq;

namespace VendingMachine.UnitTest
{
    public class LoginUnitTests
    {
        private Mock<IAuthenticationService> _authenticationService;
         
        private Mock<ILoginView> _loginView;

        public LoginUnitTests()
        {
            _authenticationService = new Mock<IAuthenticationService>();

            _loginView = new Mock<ILoginView>();
        } 

        [Fact]
        public void LoginUseCase_WhenInitializingTheUseCase_NameIsCorrect()
        {
            var _loginUseCase = new LoginUseCase(_authenticationService.Object, _loginView.Object);
            string expectedName = "login";

            Assert.Equal(expectedName, _loginUseCase.Name);
        }

        [Fact]
        public void LoginUseCase_WhenInitializingTheUseCase_DescriptionIsCorrect()
        {
            var _loginUseCase = new LoginUseCase(_authenticationService.Object, _loginView.Object);
            string expectedDescription = "Get access to administration section.";

            Assert.Equal(expectedDescription,_loginUseCase.Description);
        }

        [Theory]
        [InlineData(false)]
        public void LoginUseCase_WhenInitializingTheUseCase_CanExecuteIsFalse(bool isUserAuthenticated)
        {
            _authenticationService.Setup(permission => permission.IsUserAuthenticated).Returns(isUserAuthenticated);
            var _loginUseCase = new LoginUseCase(_authenticationService.Object, _loginView.Object);

            Assert.NotEqual(isUserAuthenticated, _loginUseCase.CanExecute);
        }

        [Fact]
        public void LoginUseCase_WhenAuthenticationServiceIsNull_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new LoginUseCase(null, _loginView.Object));
        }
        [Fact]
        public void LoginUseCase_WhenLoginViewIsNull_ArgumentNullException() 
        {
            Assert.Throws<ArgumentNullException>(() => new LoginUseCase(_authenticationService.Object, null));
        }

        [Fact]
        public void Login_WhenExecute_AskForPasswordIsExecutedOnce()
        {
            var _loginUseCase = new LoginUseCase(_authenticationService.Object, _loginView.Object);

            _loginUseCase.Execute();

            _loginView.Verify(x => x.AskForPassword(),Times.Once);
        } 
        [Fact]
        public void LoginUseCase_WhenPasswordIsNotCorrect_InvalidPasswordException()
        {
           _authenticationService.Setup(a => a.Login(It.Is<string>(i => i == "something"))).Throws(new InvalidPasswordException());

            Assert.Throws<InvalidPasswordException>(() => _authenticationService.Object.Login("something"));

        }

        [Fact]
        public void LoginUseCase_WhenPasswordIsCorrect_ExecuteOnce()
        {
            var _loginUseCase = new LoginUseCase(_authenticationService.Object, _loginView.Object);
            _loginView.Setup(x => x.AskForPassword()).Returns("supercalifragilisticexpialidocious");
            _authenticationService.Setup(x => x.Login("supercalifragilisticexpialidocious"));

            _loginUseCase.Execute();

            _authenticationService.Verify(password => password.Login("supercalifragilisticexpialidocious"), Times.Once);

        }
    }
}
