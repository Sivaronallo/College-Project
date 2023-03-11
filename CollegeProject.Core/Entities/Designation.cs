using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CollegeProject.Core.Interfaces;

namespace CollegeProject.Core.Entities;

public class Designation : IAggregateRoot
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    [Required]
    [StringLength(20)]
    public string Name { get; set; }
    public int SortingValue { get; set; }

    [StringLength(450)]
    public string UserId { get; set; }

    [StringLength(100)]
    public string SessionId { get; set; }
    public DateTime Timestamp { get; set; }

    public CollegeUser User { get; set; }
    public ICollection<CollegeUser> CollegeUser { get; set; }
}