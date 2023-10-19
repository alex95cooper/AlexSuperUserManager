using System.Net;
using AlexSuperUserManager.Common.Models;
using AlexSuperUserManager.DAL.Interfaces;
using AlexSuperUserManager.DAL.Models;
using AlexSuperUserManager.Domain.Interfaces;
using AutoMapper;

namespace AlexSuperUserManager.Domain;

public class UsersCreator : IUsersCreator
{
    private const string ExistEmailErrorMessage = "User with this nick already exists";

    private readonly IUserRepository _userRepository;
    private readonly Mapper _mapper;

    public UsersCreator(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<UserDto, User>());
        _mapper = new Mapper(config);
    }

    public async Task<IResult> AddUserAsync(UserDto userDto)
    {
        var user = await _userRepository.FindAsync(userDto.NickName);
        if (user == null)
        {
            user = _mapper.Map<User>(userDto);
            await _userRepository.CreateAsync(user);
            return ResultCreator.GetValidResult();
        }

        return ResultCreator.GetInvalidResult(ExistEmailErrorMessage,
            HttpStatusCode.BadRequest);
    }
}