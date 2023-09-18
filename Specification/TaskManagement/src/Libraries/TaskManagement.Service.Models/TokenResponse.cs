namespace TaskManagement.Service.Models;

public class TokenResponse
{
    public TokenResponse(string token, DateTime expires)
    {
        Expires = expires;
        Token = token;
    }
    public DateTime Expires { get; init; }
    public string Token { get; init; }

}