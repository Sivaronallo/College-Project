using System.ComponentModel.DataAnnotations;

namespace CollegeProject.Api.ViewModel;

public class RegisterViewModel
{
    [Required]
    [Display(Name = "User name")]
    [RegularExpression("[a-zA-Z]{1,100}", ErrorMessage = "Only alphabets allowed")]
    public string Username { get; set; }

    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required]
    [Display(Name = "User Real Name")]
    [RegularExpression("[a-zA-Z ]{1,100}", ErrorMessage = "Only alphabets allowed")]
    public string ActualName { get; set; }

    [Required]
    [Display(Name = "Designation")]
    public int DesignationId { get; set; }
    
    [Required]
    [Display(Name = "Department")]
    public int DepartmentId { get; set; }

    [Required]
    [StringLength(10)]
    [RegularExpression("[0-9]{10}", ErrorMessage = "Only numbers allowed")]
    [Display(Name = "Mobile Number")]
    public string MobileNumber { get; set; }
    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
}