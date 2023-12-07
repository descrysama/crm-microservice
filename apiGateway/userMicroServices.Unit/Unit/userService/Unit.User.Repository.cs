using Microsoft.Extensions.DependencyInjection;
using userMicroService.Tests.Common;
using userMicroService.Data.Contract.Repository;
using userMicroService.Tests.Unit.Scenarios;
using userMicroService.Data.Dto.Incomming;
using NUnit.Framework;

namespace userMicroServices.Unit.userRepository;

[TestFixture]
public class UserRepositoryUnitTest : TestBase
{
    private IUserRepository _userRepository;

    [SetUp]
    public void Setup()
    {
        SetUpTest();

        _userRepository = _serviceProvider?.GetService<IUserRepository>();
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
        var users = await _userRepository.GetAll();
        Assert.That(users, Is.Not.Null);
    }


    // Get a user by email should return the user created by the CreateUser() method above.
    [Test]
    public async Task GetUserByEmail_ReturnsOneUser()
    {
        string email = "descry@gmail.com";
        string wrongEmail = "wrong@email.com";

        var userEmail = await _userRepository.FindByEmail(wrongEmail).ConfigureAwait(false);
        Assert.That(() => userEmail, Is.EqualTo(null));

        // Act
        var user = await _userRepository.FindByEmail(email).ConfigureAwait(false);

        // Assert
        Assert.That(user, Is.Not.Null);
        Assert.That(user.Email, Is.EqualTo(email));
    }

    // Get a user by Id should return the user created by the CreateUser() method above.
    [Test]
    public async Task GetUserById_ReturnsOneUser()
    {
        int id = 100;

        // Act
        var user = await _userRepository.FindById(id).ConfigureAwait(false);

        // Assert
        Assert.That(user, Is.Not.Null);
        Assert.That(user.Id, Is.EqualTo(id));
    }

    // Create a user should return the fresh created user.
    [Test]
    public async Task CreateUser_ReturnsOneUser()
    {
        SignUpModel user = new()
        {
            Title = "Test",
            Email = "descry@gmail.com",
            Password = "password",
            LastName = "testLastName",
            Name = "TestName",
            Username = "userName"
        };

        await _userRepository.Insert(user);
        await _context.SaveChangesAsync();

        // Act
        var findCreatedUser = await _userRepository.FindByEmail(user.Email).ConfigureAwait(false);

        // Assert
        Assert.That(findCreatedUser, Is.Not.Null);
        Assert.That(findCreatedUser.Email, Is.EqualTo(user.Email));
    }
}