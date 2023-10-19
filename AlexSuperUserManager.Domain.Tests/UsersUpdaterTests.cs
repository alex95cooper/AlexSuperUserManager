using System.Net;
using AlexSuperUserManager.Common.Models;
using AlexSuperUserManager.DAL.Interfaces;
using AlexSuperUserManager.Domain.Interfaces;
using Moq;
using NUnit.Framework;

namespace AlexSuperUserManager.Domain.Tests;

public class UsersUpdaterTests
{
    private Mock<IUserRepository> _userRepositoryMock;
    private IUsersUpdater _usersUpdater;

    [SetUp]
    public void Setup()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _usersUpdater = new UsersUpdater(_userRepositoryMock.Object);
    }

    [Test]
    public async Task UpdateUserAsync_ValidUserDto_ReturnsValidResult()
    {
        var expectedStatusCode = HttpStatusCode.OK;
        var user = new UserDto
        {
            NickName = "ironman",
            FullName = "Tony Hawk",
        };

        var result = await _usersUpdater.UpdateUserAsync(user);

        Assert.IsTrue(result.IsSuccess);
        Assert.AreEqual(expectedStatusCode, result.StatusCode);
    }
}