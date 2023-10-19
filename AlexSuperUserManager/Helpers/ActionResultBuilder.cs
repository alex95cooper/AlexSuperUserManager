using System.Net;
using AlexSuperUserManager.Common;
using AlexSuperUserManager.Common.Models;
using AlexSuperUserManager.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AlexSuperUserManager.Helpers;

public class ActionResultBuilder
{
    private const string ServerError = "Internal Server Error";

    public ActionResult<ResultDto<T>> ResolveResult<T>(IResult<T> result)
    {
        return result.StatusCode switch
        {
            HttpStatusCode.OK => Ok(ResultDtoCreator.GetValidResult(result.Data)),
            HttpStatusCode.BadRequest => BadRequest(ResultDtoCreator.GetInvalidResult<T>(result.Error)),
            HttpStatusCode.NotFound => NotFound(ResultDtoCreator.GetInvalidResult<T>(result.Error)),
            _ => throw new Exception(ServerError)
        };
    }

    public ActionResult<ResultDto> ResolveResult(Domain.Interfaces.IResult result)
    {
        return result.StatusCode switch
        {
            HttpStatusCode.OK => Ok(ResultDtoCreator.GetValidResult()),
            HttpStatusCode.BadRequest => BadRequest(ResultDtoCreator.GetInvalidResult(result.Error)),
            HttpStatusCode.NotFound => NotFound(ResultDtoCreator.GetInvalidResult(result.Error)),
            _ => throw new Exception(ServerError)
        };
    }

    [NonAction]
    private static OkObjectResult Ok([ActionResultObjectValue] object value) => new(value);

    [NonAction]
    private static BadRequestObjectResult BadRequest([ActionResultObjectValue] object error) => new(error);

    [NonAction]
    private static NotFoundObjectResult NotFound([ActionResultObjectValue] object value) => new(value);
}