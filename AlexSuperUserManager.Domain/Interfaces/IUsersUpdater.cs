using AlexSuperUserManager.Common.Models;

namespace AlexSuperUserManager.Domain.Interfaces;

public interface IUsersUpdater
{
    Task<IResult> UpdateUserAsync(UserDto userDto);

    Task<IResult> DeleteUserAsync(string nickName);
}