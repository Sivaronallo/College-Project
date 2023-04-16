namespace CollegeProject.Infrastructure.Data;

public class CollegeSetting
{
    public bool EnabledLocalEmail { get; set; }
    public bool IsDefaultOtpEnabled { get; set; }
    public string MailAddress { get; set; }
    public string Secret { get; set; }
    public int RefreshTokenTtl { get; set; }
}