using KiwiLoad.Core.Exceptions.Auth;
using KiwiLoad.Core.Exceptions.Warehouses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace KiwiLoad.Infrastructure.Errors;
internal class ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);
            await HandleErrorAsync(context, exception);
        }
    }

    private static async Task HandleErrorAsync(HttpContext context, Exception exception)
    {
        var (error, code) = Map(exception);
        context.Response.StatusCode = (int)code;
        await context.Response.WriteAsJsonAsync(error);
    }

    private record Error(string Code, string Message);

    private static (Error error, HttpStatusCode code) Map(Exception exception)
        => exception switch
        {
            KiwiLoadWarehousesInvalidIdException ex => (new Error(GetErrorCode(ex), ex.Message), HttpStatusCode.BadRequest),
            KiwiLoadAuthUsernameEmptyException ex => (new Error(GetErrorCode(ex), ex.Message), HttpStatusCode.Unauthorized),
            KiwiLoadAuthPasswordEmptyException ex => (new Error(GetErrorCode(ex), ex.Message), HttpStatusCode.Unauthorized),
            _ => (new Error("error", "There was an error."), HttpStatusCode.InternalServerError)
        };

    private static string GetErrorCode(Exception exception)
        => exception.GetType().Name.Replace("Exception", string.Empty);
}
