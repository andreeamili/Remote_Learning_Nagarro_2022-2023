using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.Interfaces;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.UseCases;
using Moq;


namespace VendingMachine.UnitTest
{
    public class LogoutUnitTests
    {
        private Mock<IAuthenticationService> _authenticationService;

        public LogoutUnitTests() 
        {
            _authenticationService = new Mock<IAuthenticationService>();
        }

        [Fact]
        public void LogoutUseCase_WhenInitializingTheUseCase_NameIsCorrect()
        {
            var _logoutUseCase = new LogoutUseCase(_authenticationService.Object);
            string expectedName = "logout";

            Assert.Equal(expectedName, _logoutUseCase.Name);
        }

        [Fact]
        public void LogoutUseCase_WhenInitializingTheUseCase_DescriptionIsCorrect()
        {
            var _logoutUseCase = new LogoutUseCase(_authenticationService.Object);
            string expectedDescription = "Restrict access to administration section.";

            Assert.Equal(expectedDescription, _logoutUseCase.Description);
        }

        [Theory]
        [InlineData(true)] 
        public void LogoutUseCase_WhenInitializingTheUseCase_CanExecuteIsFalse(bool isUserAuthenticated)
        {
            _authenticationService.Setup(permission => permission.IsUserAuthenticated).Returns(isUserAuthenticated);
            var _logoutUseCase = new LogoutUseCase(_authenticationService.Object);

            Assert.Equal(isUserAuthenticated, _logoutUseCase.CanExecute);
        }

        [Fact]
        public void LogoutUseCase_WhenAuthenticationServiceIsNull_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new LogoutUseCase(null));
        }

        [Fact]
        public void Logout_WhenIsUserAuthenticatedIsFalse_Logout()
        {
            var _logoutUseCase = new LogoutUseCase(_authenticationService.Object);

            _logoutUseCase.Execute();

            _authenticationService.Verify(permission => permission.Logout(),Times.Once);
        }
    }
}
