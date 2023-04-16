using CollegeProject.Api.Authorization;
using CollegeProject.Api.Model.Users;
using CollegeProject.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CollegeProject.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var user = _userService.GetById(id);
        return Ok(user);
    }

    [HttpGet("{id}/refresh-tokens")]
    public IActionResult GetRefreshTokens(string id)
    {
        var user = _userService.GetById(id);
        return Ok(user.RefreshTokens);
    }
}
