#nullable disable
namespace TaskManagement.Shared.Common;

public  class JwtConfig
{
  
    public Uri ValidIssuer { get; set; }

   
    public Uri ValidAudience { get; set; }

   
    public string Secret { get; set; }

  
    public long ExpiresIn { get; set; }
}