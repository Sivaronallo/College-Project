using System.ComponentModel.DataAnnotations;
using CollegeProject.Core.Interfaces;

namespace CollegeProject.Core.Entities.Message;

public class EmailLog : IAggregateRoot
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Subject { get; set; }

    [Required]
    [StringLength(100)]
    public string EmailId { get; set; }

    [Required]
    [StringLength(1000)]
    public string Body { get; set; }

    [StringLength(100)]
    public string SessionId { get; set; }

    [StringLength(450)]
    public string SentUserId { get; set; }
    public DateTime SentTimeStamp { get; set; }
    public CollegeUser SentUser { get; set; }
}