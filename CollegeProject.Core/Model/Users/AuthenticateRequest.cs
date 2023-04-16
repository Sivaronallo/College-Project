using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CollegeProject.Core.Entities;

namespace CollegeProject.Api.Model.Users;

public class AuthenticateRequest
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}
public class AuthenticateResponse
{
    public string Id { get; set; }
    /* To use when needed
     public string FirstName { get; set; }
    public string LastName { get; set; }*/
    public string Username { get; set; }
    public string JwtToken { get; set; }

    [JsonIgnore] // refresh token is returned in http only cookie
    public string RefreshToken { get; set; }

    public AuthenticateResponse(CollegeUser user, string jwtToken, string refreshToken)
    {
        Id = user.Id;
        Username = user.UserName;
        JwtToken = jwtToken;
        RefreshToken = refreshToken;
    }
}
public class RevokeTokenRequest
{
    public string Token { get; set; }
}