using System.Text;
using api.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using api.CustomException;
using Microsoft.AspNetCore.Mvc;

namespace api.Filters;

public class AdminAuthorize : Attribute, IAuthorizationFilter
{

    private readonly IAuthTokenService _authTokenService;

    public AdminAuthorize(IAuthTokenService authTokenService)
    {
        _authTokenService = authTokenService;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {

        string? bearerToken = context.HttpContext.Request.Headers["Authorization"];

        if (string.IsNullOrEmpty(bearerToken) || !bearerToken.StartsWith("Bearer "))
        {
            context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            return;
        }


        string token = bearerToken.Replace("Bearer ", "");
        if (!IsAuthorized(token))
        {
            context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
            return;
        }

        context.HttpContext.Items["UserUid"] = _authTokenService.GetPayload(token).Uid;
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