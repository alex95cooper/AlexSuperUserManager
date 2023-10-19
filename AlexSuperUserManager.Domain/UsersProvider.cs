using System.Net;
using AlexSuperUserManager.Common.Models;
using AlexSuperUserManager.DAL.Interfaces;
using AlexSuperUserManager.DAL.Models;
using AlexSuperUserManager.Domain.Interfaces;
using AutoMapper;

namespace AlexSuperUserManager.Domain;

public class UsersProvider : IUsersProvider
{
    private readonly IUserRepository _userRepository;
    private readonly Mapper _mapper;
    private readonly Mapper _listMapper;

    public UsersProvider(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        var config = new MapperConfiguration(cfg =>
            cfg.CreateMap<User, UserDto>());
        _listMapper = new Mapper(config);
        _mapper = new Mapper(new MapperConfiguration(cfg =>
            cfg.CreateMap<User, UserDto>()));
    }

    public async Task<IResult<List<UserDto>>> GetUsersAsync()
    {
        var userList = await _userRepository.GetAllAsync();
        var listDto = _listMapper.Map<List<UserDto>>(userList);
        return ResultCreator.GetValidResult(listDto, HttpStatusCode.OK);
    }

    public async Task<IResult<UserDto>> GetUserAsync(string nickName)
    {
        User user = await _userRepository.FindAsync(nickName);
        UserDto userDto = _mapper.Map<UserDto>(user);
        return ResultCreator.GetValidResult(userDto, HttpStatusCode.OK);
    }
}