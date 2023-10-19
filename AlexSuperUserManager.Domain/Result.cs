using System.Net;
using AlexSuperUserManager.Domain.Interfaces;

namespace AlexSuperUserManager.Domain;

public class Result : IResult
{
    public string Error { get; init; }
    public bool IsSuccess { get; init; }
    public HttpStatusCode StatusCode { get; init; }
}

public class Result<T> : Result, IResult<T>
{
    public T Data { get; init; }
}