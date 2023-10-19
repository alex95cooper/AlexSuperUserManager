using System.Net;
using AlexSuperUserManager.Common.Models;
using AlexSuperUserManager.DAL.Interfaces;
using AlexSuperUserManager.Domain.Interfaces;
using Moq;
using NUnit.Framework;

namespace AlexSuperUserManager.Domain.Tests;

public class UsersCreatorTests
{
    private Mock<IUserRepository> _userRepositoryMock;
    private IUsersCreator _usersCreator;

    [SetUp]
    public void Setup()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _usersCreator = new UsersCreator(_userRepositoryMock.Object);
    }

    [Test]
    public async Task AddUserAsync_ValidUserDto_ReturnsValidResult()
    {
        var expectedStatusCode = HttpStatusCode.OK;
        var user = new UserDto
        {
            NickName = "ironman",
            FullName = "Tony Stark",
        };

        var result = await _usersCreator.AddUserAsync(user);

        Assert.IsTrue(result.IsSuccess);
        Assert.AreEqual(expectedStatusCode, result.StatusCode);
    }
}