using CollegeProject.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CollegeProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfirmEmailController : ControllerBase
    {
        private readonly UserManager<CollegeUser> _userManager;

        public ConfirmEmailController(UserManager<CollegeUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return BadRequest("Invalid token");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                return Ok("Email confirmed");
            }

            return BadRequest(result.Errors);
        }

    }
}
