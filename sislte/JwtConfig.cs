using Microsoft.IdentityModel.Tokens;

namespace sislte;

public static class JwtConfig
{
    public static SecurityKey Key { get; set; }
    public static string Issuer { get; set; }
    public static string Audience { get; set; }
}