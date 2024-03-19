using System.Net;
using System.Text.Json;
using api.CustomException;

namespace cube4api.Middleware;

public class ExecptionMiddleware
{

    private readonly RequestDelegate _next;


    public ExecptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode status;
        string message;
        var stackTrace = String.Empty;

        var exceptionType = exception.GetType();
        if (exceptionType == typeof(BadRequestException))
        {
            message = exception.Message;
            status = HttpStatusCode.BadRequest;
        }
        else if (exceptionType == typeof(NotFoundExecption))
        {
            message = exception.Message;
            status = HttpStatusCode.NotFound;
        }
        else if (exceptionType == typeof(UnauthorizedExecption))
        {
            message = exception.Message;
            status = HttpStatusCode.Unauthorized;
        }
        else if (exceptionType == typeof(ConflictException))
        {
            message = exception.Message;
            status = HttpStatusCode.Conflict;
        }
        else
        {
            status = HttpStatusCode.InternalServerError;
            message = exception.Message;
            // if (env.IsEnvironment("Development"))
            //     stackTrace = exception.StackTrace;
        }


        var result = JsonSerializer.Serialize(new { error = message, stackTrace });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)status;
        return context.Response.WriteAsync(result);
    }
}