using AlexSuperUserManager.Common.Models;

namespace AlexSuperUserManager.Domain.Interfaces;

public interface IUsersCreator
{
    Task<IResult> AddUserAsync(UserDto userDto);
}