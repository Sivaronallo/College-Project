using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CollegeProject.Core.Interfaces;

namespace CollegeProject.Core.Entities;

public class Department : IAggregateRoot
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    [Required]
    [StringLength(300)]
    [Display(Name = "Department Name")]
    public string Name { get; set; }

    [StringLength(5)]
    [Display(Name = "Department Short Code")]
    public string ShortCode { get; set; }

    [StringLength(450)]
    public string UserId { get; set; }

    [StringLength(100)]
    public string SessionId { get; set; }
    public DateTime Timestamp { get; set; }

    public CollegeUser User { get; set; }
    public ICollection<CollegeUser> CollegeUsers { get; set; }
}