using System.Text;
using api.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using api.CustomException;

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
            throw new UnauthorizedExecption("Unauthorized");
            return;

        }

        string token = bearerToken.Replace("Bearer ", "");

        if (!IsAuthorized(token))
        {
            throw new UnauthorizedExecption("Unauthorized");
            return;
        }

        context.HttpContext.Items["User"] = _authTokenService.GetPayload(token);

        base.OnActionExecuted(context);
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