using System.Text;
using api.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace api.Filters;

public class AdminAuthorize : ActionFilterAttribute
{

    private readonly IAuthTokenService _authTokenService;

    public AdminAuthorize(IAuthTokenService authTokenService)
    {
        _authTokenService = authTokenService;
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        string? bearerToken = context.HttpContext.Request.Headers["Authorization"];

        if (bearerToken == null)
        {
            Unauthorized(context);
            return;

        }

        string token = bearerToken.Replace("Bearer ", "");

        if (!IsAuthorized(token))
        {
            Unauthorized(context);
            return;
        }

        context.HttpContext.Items["User"] = _authTokenService.GetPayload(token);

        base.OnActionExecuted(context);
    }


    private void Unauthorized(ActionExecutedContext context)
    {
        context.HttpContext.Response.StatusCode = 401;
        context.HttpContext.Response.BodyWriter.WriteAsync(new ReadOnlyMemory<byte>(Encoding.UTF8.GetBytes("Unauthorized")));
    }

    private bool IsAuthorized(string token)
    {
        if (string.IsNullOrEmpty(token))
        {
            return false;
        }

        bool isValid = _authTokenService.ValidateToken(token);

        return isValid;
    }

}