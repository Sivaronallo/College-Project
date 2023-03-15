using System.Text;
using CollegeProject.Api.ViewModel;
using CollegeProject.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;


namespace CollegeProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<CollegeUser> _userManager;
        private readonly SignInManager<CollegeUser> _signInManager;
        private readonly IUserStore<CollegeUser> _userStore;
        private readonly IEmailSender _emailSender;

        public RegisterController(UserManager<CollegeUser> userManager, SignInManager<CollegeUser> signInManager, IEmailSender emailSender, IUserStore<CollegeUser> userStore)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _userStore = userStore;
        }

        // POST api/<RegisterController>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new CollegeUser()
            {
                UserName = model.Email, 
                Email = model.Email, 
                ActualName = model.ActualName,
                DesignationId = model.DesignationId, 
                DepartmentId = model.DepartmentId,
                PhoneNumber = model.MobileNumber,
                DateCreated = DateTime.Now,
                IsActive = true,
                PhoneNumberConfirmed = true
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Action("ConfirmEmail", "ConfirmEmail", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                await _emailSender.SendEmailAsync(model.Email, "Confirm your email",
                    $"Please confirm your account by clicking this link: <a href='{callbackUrl}'>link</a>");

                return Ok("Registration successful. Please check your email to confirm your account.");
            }                       
            return BadRequest(result.Errors);
        }

        // PUT api/<RegisterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RegisterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
