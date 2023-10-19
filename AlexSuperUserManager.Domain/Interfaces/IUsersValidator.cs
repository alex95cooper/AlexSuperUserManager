using AlexSuperUserManager.Common.Models;

namespace AlexSuperUserManager.Domain.Interfaces;

public interface IUsersValidator
{
    Task<IResult> CheckIfUserExist(string nickName);

    IResult CheckIfUserIsValid(UserDto userDto);

    Task<IResult> CheckIfUserUpdateIsValid(UserDto userDto);
}