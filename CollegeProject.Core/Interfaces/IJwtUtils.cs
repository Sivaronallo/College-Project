using CollegeProject.Core.Entities;

namespace CollegeProject.Core.Interfaces;

public interface IJwtUtils
{
    public string GenerateJwtToken(CollegeUser user);
    public string ValidateJwtToken(string token);
    public RefreshToken GenerateRefreshToken(string ipAddress);

}