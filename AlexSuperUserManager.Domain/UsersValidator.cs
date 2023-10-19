using System.Net;
using System.Text.RegularExpressions;
using AlexSuperUserManager.Common.Models;
using AlexSuperUserManager.DAL.Interfaces;
using AlexSuperUserManager.DAL.Models;
using AlexSuperUserManager.Domain.Interfaces;

namespace AlexSuperUserManager.Domain;

public class UsersValidator : IUsersValidator
{
    private readonly IUserRepository _userRepository;

    public UsersValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IResult> CheckIfUserExist(string nickName)
    {
        User user = await _userRepository.FindAsync(nickName);
        return user == null
            ? ResultCreator.GetInvalidResult(
                Constants.ErrorMessages.UserNotFound, HttpStatusCode.NotFound)
            : ResultCreator.GetValidResult();
    }

    public IResult CheckIfUserIsValid(UserDto userDto)
    {
        if (userDto == null)
        {
            return ResultCreator.GetInvalidResult(
                Constants.ErrorMessages.InvalidUser, HttpStatusCode.BadRequest);
        }

        var nickResult = CheckIfNickNameIsValid(userDto.NickName);
        var nameResult = CheckIfFullNameIsValid(userDto.FullName);
        if (!nickResult.IsSuccess || !nameResult.IsSuccess)
        {
            string error = nickResult.IsSuccess ? nameResult.Error : nickResult.Error;
            return ResultCreator.GetInvalidResult(error, HttpStatusCode.BadRequest);
        }

        return ResultCreator.GetValidResult();
    }

    public async Task<IResult> CheckIfUserUpdateIsValid(UserDto userDto)
    {
        var existResult = await CheckIfUserExist(userDto.NickName);
        if (!existResult.IsSuccess)
        {
            return existResult;
        }

        var result = CheckIfUserIsValid(userDto);
        return !result.IsSuccess ? result : ResultCreator.GetValidResult();
    }

    private static IResult CheckIfNickNameIsValid(string nickName)
    {
        string error = Constants.ErrorMessages.InvalidNickName;
        if (nickName == null)
        {
            return ResultCreator.GetInvalidResult(error, HttpStatusCode.BadRequest);
        }

        Regex regex = new(Constants.User.NickPattern);
        return regex.IsMatch(nickName)
            ? ResultCreator.GetValidResult()
            : ResultCreator.GetInvalidResult(error, HttpStatusCode.BadRequest);
    }

    private static IResult CheckIfFullNameIsValid(string fullName)
    {
        string error = Constants.ErrorMessages.InvalidFullName;
        if (fullName == null)
        {
            return ResultCreator.GetInvalidResult(error, HttpStatusCode.BadRequest);
        }

        Regex regex = new(Constants.User.FullNamePattern);
        return regex.IsMatch(fullName)
            ? ResultCreator.GetValidResult()
            : ResultCreator.GetInvalidResult(error, HttpStatusCode.BadRequest);
    }
}