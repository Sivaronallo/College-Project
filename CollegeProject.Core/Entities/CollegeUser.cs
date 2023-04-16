using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace CollegeProject.Core.Entities;

public class CollegeUser : IdentityUser
{
    [Required]
    [StringLength(150)]
    public string ActualName { get; set; }

    [Required]
    public int DepartmentId { get; set; }

    [Required]
    public int DesignationId { get; set; }

    public DateTime DateCreated { get; set; }
    public bool IsActive { get; set; }
    public Designation Designation { get; set; }
    public Department Department { get; set; }
    public string DisplayName => $"{ActualName} ({PhoneNumber})";
    [JsonIgnore]
    public List<RefreshToken> RefreshTokens { get; set; }
}
