namespace HR.LeaveManagement.Application.Models.Email;

public class EmailSettings
{
    public string ApiKey { get; set; }
    public string FromAddress { get; set; }
    public string FromName { get; set; }

    public string SmtpHost { get; set; }
    public string SmtpPort { get; set; }
    public string SmtpCredUsername { get; set; }
    public string SmtpCredPassword { get; set; }
}