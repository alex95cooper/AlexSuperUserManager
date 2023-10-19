using NUnit.Framework;

namespace AlexSuperUserManager.Common.Tests;

public class ResultDtoCreatorTests
{
    [Test]
    public void GetInvalidResultGeneric_ErrorString_ReturnsResult()
    {
        string errorMessage = "Goodbye World!";

        var result = ResultDtoCreator.GetInvalidResult<int>(errorMessage);

        Assert.IsFalse(result.IsSuccess);
        Assert.AreEqual(errorMessage, result.Error);
    }

    [Test]
    public void GetInvalidResult_ErrorString_ReturnsInvalidResult()
    {
        string errorMessage = "Goodbye World!";

        var result = ResultDtoCreator.GetInvalidResult(errorMessage);

        Assert.IsFalse(result.IsSuccess);
        Assert.AreEqual(errorMessage, result.Error);
    }

    [Test]
    public void GetValidResult_DataString_ReturnsValidResult()
    {
        string data = "Data";

        var result = ResultDtoCreator.GetValidResult(data);

        Assert.IsTrue(result.IsSuccess);
        Assert.AreEqual(data, result.Data);
    }

    [Test]
    public void GetValidResult_Empty_ReturnValidResult()
    {
        var result = ResultDtoCreator.GetValidResult();

        Assert.IsTrue(result.IsSuccess);
    }
}