using CollegeProject.Api.Model.Users;
using CollegeProject.Core.Entities;

namespace CollegeProject.Core.Interfaces;

public interface IUserService
{
    AuthenticateResponse Authenticate(CollegeUser user, string ipAddress);
    AuthenticateResponse RefreshToken(string token, string ipAddress);
    void RevokeToken(string token, string ipAddress);
    IEnumerable<CollegeUser> GetAll();
    CollegeUser GetById(string id);
}
