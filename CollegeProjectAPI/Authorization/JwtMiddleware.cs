using CollegeProject.Core.Interfaces;
using CollegeProject.Infrastructure.Data;
using Microsoft.Extensions.Options;

namespace CollegeProject.Api.Authorization;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly CollegeSetting _settings;

    public JwtMiddleware(RequestDelegate next, IOptions<CollegeSetting> settings)
    {
        _next = next;
        _settings = settings.Value;
    }

    public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var userId = jwtUtils.ValidateJwtToken(token);
        if (userId != null)
        {
            // attach user to context on successful jwt validation
            context.Items["User"] = userService.GetById(userId);
        }

        await _next(context);
    }
}