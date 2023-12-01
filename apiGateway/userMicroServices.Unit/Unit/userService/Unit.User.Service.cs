using Microsoft.Extensions.DependencyInjection;
using userMicroService.Tests.Common;
using userMicroService.Data.Contract.Repository;
using userMicroService.Tests.Unit.Scenarios;
using userMicroService.Data.Dto.Incomming;
using NUnit.Framework;
using userMicroService.Data.Contract.Services;
using userMicroService.Entities;
using userMicroService.Data.Dto.Outcomming;

namespace userMicroServices.Unit.userService
{
    [TestFixture]
    public class UserServiceUnitTest : TestBase
    {
        private IUserService _userService;

        [SetUp]
        public void Setup()
        {
            SetUpTest();

            _userService = _serviceProvider?.GetService<IUserService>();
            _context.CreateUsers();
        }

        [TearDown]
        public void TearDown()
        {
            CleanTest();
        }

        [Test]
        public async Task GetAllUsers_ReturnsListOfUsers()
        {
            var users = await _userService.GetAll();
            Assert.That(users, Is.Not.Null);
            Assert.That(users, Is.TypeOf<List<User>>());
        }

        [Test]
        public async Task GetUserById_ReturnsUser()
        {
            int userId = 2;
            var user = await _userService.GetById(userId);
            Assert.That(user, Is.Not.Null);
            Assert.That(user, Is.TypeOf<User>());
        }

        [Test]
        public async Task SignIn_ReturnsUser()
        {
            SignInModel model = new()
            {
                Email = "descry@gmail.com",
                Password = "Google59"
            };
            var user = await _userService.SignIn(model);
            Assert.That(user, Is.Not.Null);
            Assert.That(user.Email, Is.EqualTo(model.Email));
            Assert.That(user, Is.TypeOf<UserRead>());
        }
    }
}
