using System.Net;
using AlexSuperUserManager.Common.Models;
using AlexSuperUserManager.Domain;
using AlexSuperUserManager.Helpers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace AlexSuperUserManager.Tests;

public class ActionResultMakerTests
{
    private ActionResultBuilder _resultBuilder;

    [SetUp]
    public void Setup()
    {
        _resultBuilder = new ActionResultBuilder();
    }

    [Test]
    public void ResolveResult_Result_ReturnsActionResult()
    {
        string data = "Data";
        var statusCode = HttpStatusCode.OK;
        var expectedResult = new ResultDto<string>
        {
            Data = data,
            IsSuccess = true
        };

        var actionResult = _resultBuilder.ResolveResult(new Result<string>
        {
            Data = data, IsSuccess = true, StatusCode = statusCode
        });

        var objectResult = ((OkObjectResult) actionResult.Result!).Value!;
        var result = (ResultDto<string>) objectResult;

        Assert.AreEqual(expectedResult.Data, result.Data);
        Assert.AreEqual(expectedResult.IsSuccess, result.IsSuccess);
    }
}