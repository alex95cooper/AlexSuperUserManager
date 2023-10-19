using AlexSuperUserManager.Common.Models;

namespace AlexSuperUserManager.Domain.Interfaces;

public interface IUsersProvider
{
    Task<IResult<List<UserDto>>> GetUsersAsync();

    Task<IResult<UserDto>> GetUserAsync(string nickName);
}