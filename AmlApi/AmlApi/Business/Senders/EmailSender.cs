using System;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using AmlApi.Business.Senders.Interfaces;

namespace AmlApi.Business.Senders;

public class EmailSender : IEmailSender
{
    public async Task SendEmail(string email)
    {
        var fromAddress = new MailAddress("advancedmedialibrary@gmail.com", "AML Admin");
        var toAddress = new MailAddress(email, "To Name");
        const string fromPassword = "jfqk umob hetv yxcr";
        const string subject = "Overdue Media";
        const string body = "You haven't returned your media on time!";
        
        var smtp = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        };

        using (var message = new MailMessage(fromAddress, toAddress)
               {
                   Subject = subject,
                   Body = body
               })
        {
            smtp.Send(message);
        }
    }
}