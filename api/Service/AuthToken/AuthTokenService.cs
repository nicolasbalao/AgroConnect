
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace api.Admin.Services;

public class Payload
{
    public string Uid { get; set; } = string.Empty;
    public double Exp { get; set; }

}

public class AuthTokenService(string secret) : IAuthTokenService
{
    private readonly string _secret = secret;

    public string GenerateToken(string uid, double experiaionTime)
    {
        var payload = $"{{\"uid\":\"{uid}\",\"exp\":{experiaionTime}}}";

        var payloadBytes = Encoding.UTF8.GetBytes(payload);
        var keyBytes = Encoding.UTF8.GetBytes(_secret);

        using (var hmac = new HMACSHA256(keyBytes))
        {
            var hash = hmac.ComputeHash(payloadBytes);
            var hashString = Convert.ToBase64String(hash);
            var payloadBase64 = Convert.ToBase64String(payloadBytes);
            return $"{payloadBase64}.{hashString}";
        }

    }

    public Payload GetPayload(string token)
    {
        var parts = token.Split('.');
        var payloadBase64 = parts[0];
        var payloadBytes = Convert.FromBase64String(payloadBase64);


        return DeserializePayload(payloadBytes);

    }


    public bool ValidateToken(string token)
    {
        try
        {
            var parts = token.Split('.');
            var payloadBase64 = parts[0];
            var hash = parts[1];

            var payloadBytes = Convert.FromBase64String(payloadBase64);
            var keyBytes = Encoding.UTF8.GetBytes(_secret);

            using (var hmac = new HMACSHA256(keyBytes))
            {
                var hashComputed = hmac.ComputeHash(payloadBytes);
                var hashStringComputed = Convert.ToBase64String(hashComputed);

                if (hashStringComputed != hash)
                    return false;


                var payload = DeserializePayload(payloadBytes);



                var exp = new DateTime(1970, 1, 1).AddSeconds(payload.Exp);

                if (exp < DateTime.UtcNow)
                    return false;

                return true;
            }
        }
        catch
        {
            return false;
        }

    }
    private static Payload DeserializePayload(byte[] payloadBytes)
    {
        var payloadJson = Encoding.UTF8.GetString(payloadBytes);
        Payload payload = JsonConvert.DeserializeObject<Payload>(payloadJson)!;
        return payload;

    }
}