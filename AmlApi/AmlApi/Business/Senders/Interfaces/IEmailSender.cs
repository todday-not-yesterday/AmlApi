using System.Threading.Tasks;

namespace AmlApi.Business.Senders.Interfaces;

public interface IEmailSender
{
    Task SendEmail(string email);
}