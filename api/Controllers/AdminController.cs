using api.Admin.Filters;
using Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;
using api.Admin.Services;

namespace api.Admin.Controller;

[ApiController]
[Route("api/v1/[controller]")]
public class AdminController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IAuthTokenService _authTokenService;


    public AdminController(IConfiguration configuration, IAuthTokenService authTokenService)
    {
        _configuration = configuration;
        _authTokenService = authTokenService;
    }


    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        if (request.Password == _configuration.GetSection("Env").GetValue<string>("ADMIN_PASSWORD"))
        {
            var uid = Guid.NewGuid().ToString();
            var expirationTime = DateTime.UtcNow.AddDays(1).Subtract(new DateTime(1970, 1, 1)).TotalSeconds;

            var token = _authTokenService.GenerateToken(uid, expirationTime);



            Response.Headers.Append("Authorization", "Bearer " + token);

            return Ok("Login successful!");

        }
        else
        {
            return Unauthorized("Invalid password");
        }
    }

    [HttpPost("validate")]
    [ServiceFilter(typeof(AdminAuthorize))]
    public IActionResult Validate([FromBody] string token)
    {
        if (_authTokenService.ValidateToken(token))
        {
            return Ok("Token is valid");
        }
        else
        {
            return Unauthorized("Token is invalid");
        }
    }

}