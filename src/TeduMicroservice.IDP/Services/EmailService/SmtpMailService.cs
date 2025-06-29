using TeduMicroservice.IDP.Common;

namespace TeduMicroservice.IDP.Services.EmailService;

public class SmtpMailService : IEmailSender
{
    private readonly SMTPEmailSetting _smtpEmailSetting;

    public SmtpMailService(SMTPEmailSetting smtpEmailSetting)
    {
        _smtpEmailSetting = smtpEmailSetting;
    }

    public void SendMail(string recipient, string subject, string body, bool isBodyHtml = false, string sender = null)
    {
        // assume send mail implemented
        throw new NotImplementedException();
    }
}