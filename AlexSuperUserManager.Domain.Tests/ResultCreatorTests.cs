using System.Net;
using NUnit.Framework;

namespace AlexSuperUserManager.Domain.Tests;

public class ResultCreatorTests
{
    [Test]
    public void GetInvalidResult_ErrorString_ReturnInvalidResult()
    {
        string message = "Goodbye World!";
        var expectedStatusCode = HttpStatusCode.BadRequest;

        var result = ResultCreator.GetInvalidResult(message, expectedStatusCode);

        Assert.IsFalse(result.IsSuccess);
        Assert.AreEqual(expectedStatusCode, result.StatusCode);
        Assert.AreEqual(message, result.Error);
    }

    [Test]
    public void GetInvalidResultGeneric_ErrorString_ReturnInvalidResult()
    {
        string message = "Goodbye World!";
        var expectedStatusCode = HttpStatusCode.BadRequest;

        var result = ResultCreator.GetInvalidResult<int>(message, expectedStatusCode);

        Assert.IsFalse(result.IsSuccess);
        Assert.AreEqual(expectedStatusCode, result.StatusCode);
        Assert.AreEqual(message, result.Error);
    }

    [Test]
    public void GetValidResult_DataString_ReturnValidResult()
    {
        string data = "Data";
        var statusCode = HttpStatusCode.BadRequest;

        var result = ResultCreator.GetValidResult(data, statusCode);

        Assert.IsTrue(result.IsSuccess);
        Assert.AreEqual(data, result.Data);
    }

    [Test]
    public void GetValidResult_Void_ReturnValidResult()
    {
        var expectedStatusCode = HttpStatusCode.OK;

        var result = ResultCreator.GetValidResult();

        Assert.IsTrue(result.IsSuccess);
        Assert.AreEqual(expectedStatusCode, result.StatusCode);
    }
}