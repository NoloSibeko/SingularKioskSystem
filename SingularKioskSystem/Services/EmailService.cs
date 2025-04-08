/*using MailKit.Net.Smtp;
using MimeKit;
using SingularKioskSystem.Services;

namespace SingularKioskSystem.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(string email, string subject, string message)
    {
        var emailSettings = _configuration.GetSection("EmailSettings");

        var mimeMessage = new MimeMessage();
        mimeMessage.From.Add(new MailboxAddress(
            emailSettings["SenderName"],
            emailSettings["SenderEmail"]));
        mimeMessage.To.Add(new MailboxAddress("", email));
        mimeMessage.Subject = subject;

        mimeMessage.Body = new TextPart("html")
        {
            Text = message
        };

        using var client = new SmtpClient();

        try
        {
            await client.ConnectAsync(
                emailSettings["MailServer"],
                int.Parse(emailSettings["MailPort"]),
                bool.Parse(emailSettings["UseSSL"]));

            await client.AuthenticateAsync(
                emailSettings["SenderEmail"],
                emailSettings["Password"]);

            await client.SendAsync(mimeMessage);
        }
        finally
        {
            await client.DisconnectAsync(true);
        }
    }
}*/