namespace api.Admin.Services;

public interface IAuthTokenService
{
    string GenerateToken(string uid, double experiaionTime);
    bool ValidateToken(string token);

    Payload GetPayload(string token);
}