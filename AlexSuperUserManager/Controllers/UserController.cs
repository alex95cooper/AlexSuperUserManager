using System.Net;
using AlexSuperUserManager.Common.Models;
using AlexSuperUserManager.Domain;
using AlexSuperUserManager.Domain.Interfaces;
using AlexSuperUserManager.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace AlexSuperUserManager.Controllers;

[ApiController]
public class UserController : Controller
{
    private readonly IUsersCreator _usersCreator;
    private readonly IUsersProvider _usersProvider;
    private readonly IUsersUpdater _usersUpdater;
    private readonly IUsersValidator _usersValidator;
    private readonly ActionResultBuilder _resultBuilder;

    public UserController(IUsersCreator usersCreator, IUsersProvider usersProvider,
        IUsersUpdater usersUpdater, IUsersValidator usersValidator)
    {
        _usersCreator = usersCreator;
        _usersProvider = usersProvider;
        _usersUpdater = usersUpdater;
        _usersValidator = usersValidator;
        _resultBuilder = new ActionResultBuilder();
    }

    [HttpGet("services/test-service/users")]
    public async Task<ActionResult<ResultDto<List<UserDto>>>> GetAll()
    {
        var result = await _usersProvider.GetUsersAsync();
        return _resultBuilder.ResolveResult(result);
    }

    [HttpGet("services/test-service/users/{nickName}")]
    public async Task<ActionResult<ResultDto<UserDto>>> Get([FromRoute] string nickName)
    {
        var validationResult = await _usersValidator.CheckIfUserExist(nickName);
        if (validationResult.IsSuccess)
        {
            var result = await _usersProvider.GetUserAsync(nickName);
            return _resultBuilder.ResolveResult(result);
        }

        return _resultBuilder.ResolveResult(ResultCreator.GetInvalidResult<UserDto>(
            validationResult.Error, HttpStatusCode.BadRequest));
    }

    [HttpPost("services/test-service/users/add")]
    public async Task<ActionResult<ResultDto>> Add([FromBody] UserDto userDto)
    {
        var validationResult = _usersValidator.CheckIfUserIsValid(userDto);
        if (validationResult.IsSuccess)
        {
            var result = await _usersCreator.AddUserAsync(userDto);
            return _resultBuilder.ResolveResult(result);
        }

        return _resultBuilder.ResolveResult(validationResult);
    }

    [HttpPut("services/test-service/users/{nickName}/update")]
    public async Task<ActionResult<ResultDto>> Update([FromBody] UserDto userDto)
    {
        var validationResult = await _usersValidator.CheckIfUserUpdateIsValid(userDto);
        if (validationResult.IsSuccess)
        {
            var result = await _usersUpdater.UpdateUserAsync(userDto);
            return _resultBuilder.ResolveResult(result);
        }

        return _resultBuilder.ResolveResult(validationResult);
    }

    [HttpDelete("services/test-service/users/{nickName}/delete")]
    public async Task<ActionResult<ResultDto>> Delete([FromRoute] string nickName)
    {
        var validationResult = await _usersValidator.CheckIfUserExist(nickName);
        if (validationResult.IsSuccess)
        {
            var result = await _usersUpdater.DeleteUserAsync(nickName);
            return _resultBuilder.ResolveResult(result);
        }

        return _resultBuilder.ResolveResult(validationResult);
    }
}