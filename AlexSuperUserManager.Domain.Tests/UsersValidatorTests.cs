using System.Net;
using AlexSuperUserManager.Common.Models;
using AlexSuperUserManager.DAL.Interfaces;
using AlexSuperUserManager.Domain.Interfaces;
using Moq;
using NUnit.Framework;

namespace AlexSuperUserManager.Domain.Tests;

public class UsersValidatorTests
{
    private Mock<IUserRepository> _userRepositoryMock;
    private IUsersValidator _usersValidator;

    [SetUp]
    public void Setup()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _usersValidator = new UsersValidator(_userRepositoryMock.Object);
    }

    [Test]
    public async Task CheckIfUserExist_InvalidNickName_ReturnsInvalidResult()
    {
        string nickName = "ironman38";
        var expectedStatusCode = HttpStatusCode.NotFound;
        var expectedMessage = Constants.ErrorMessages.UserNotFound;

        var result = await _usersValidator.CheckIfUserExist(nickName);

        Assert.IsFalse(result.IsSuccess);
        Assert.AreEqual(expectedStatusCode, result.StatusCode);
        Assert.AreEqual(expectedMessage, result.Error);
    }

    [Test]
    public void CheckIfUserIsValid_InvalidFullName_ReturnsInvalidResult()
    {
        var userDto = new UserDto
        {
            NickName = "qwerty",
            FullName = "Alexeybondarenko"
        };
        var expectedStatusCode = HttpStatusCode.BadRequest;
        string expectedMessage = Constants.ErrorMessages.InvalidFullName;

        var result = _usersValidator.CheckIfUserIsValid(userDto);

        Assert.IsFalse(result.IsSuccess);
        Assert.AreEqual(expectedStatusCode, result.StatusCode);
        Assert.AreEqual(expectedMessage, result.Error);
    }

    [Test]
    public void CheckIfUserIsValid_ValidUserDto_ReturnsValidResult()
    {
        var userDto = new UserDto
        {
            NickName = "qwerty",
            FullName = "Alexey Bondarenko"
        };
        var expectedStatusCode = HttpStatusCode.OK;

        var result = _usersValidator.CheckIfUserIsValid(userDto);

        Assert.IsTrue(result.IsSuccess);
        Assert.AreEqual(expectedStatusCode, result.StatusCode);
    }

    [Test]
    public async Task CheckIfUserUpdateIsValid_InvalidNickName_ReturnsInvalidResult()
    {
        // Arrange 
        var guitarDto = new UserDto
        {
            NickName = "ironman38"
        };
        var expectedStatusCode = HttpStatusCode.NotFound;
        var expectedMessage = Constants.ErrorMessages.UserNotFound;

        // Act
        var result = await _usersValidator.CheckIfUserUpdateIsValid(guitarDto);

        // Assert
        Assert.IsFalse(result.IsSuccess);
        Assert.AreEqual(expectedStatusCode, result.StatusCode);
        Assert.AreEqual(expectedMessage, result.Error);
    }
}