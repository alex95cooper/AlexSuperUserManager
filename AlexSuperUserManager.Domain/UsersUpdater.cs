using AlexSuperUserManager.Common.Models;
using AlexSuperUserManager.DAL.Interfaces;
using AlexSuperUserManager.DAL.Models;
using AlexSuperUserManager.Domain.Interfaces;

namespace AlexSuperUserManager.Domain;

public class UsersUpdater : IUsersUpdater
{
    private readonly IUserRepository _userRepository;

    public UsersUpdater(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IResult> UpdateUserAsync(UserDto userDto)
    {
        User userDal = await _userRepository.FindAsync(userDto.NickName);
        if (userDal != null)
        {
            userDal.NickName = userDto.NickName;
            userDal.FullName = userDto.FullName;
        }

        await _userRepository.UpdateAsync(userDal);
        return ResultCreator.GetValidResult();
    }

    public async Task<IResult> DeleteUserAsync(string nickName)
    {
        User user = _userRepository.FindAsync(nickName).Result;
        await _userRepository.DeleteAsync(user);
        return ResultCreator.GetValidResult();
    }
}