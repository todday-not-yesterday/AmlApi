using System.Threading.Tasks;
using AmlApi.Business.Processor.Interfaces;
using AmlApi.Business.Senders;
using AmlApi.Business.Senders.Interfaces;
using AmlApi.DataAccess;
using AmlApi.DataAccess.Queries;
using AmlApi.DataAccess.Queries.Interfaces;

namespace AmlApi.Business.Processor;

public class NotificationsToSendProcessor : INotificationsToSendProcessor
{
    private readonly IDataContextFactory dataContextFactory;
    private readonly IGetNotificationsToSendQuery getNotificationsToSendQuery;
    private readonly IEmailSender emailSender;

    public NotificationsToSendProcessor(
        IDataContextFactory dataContextFactory, 
        IGetNotificationsToSendQuery getNotificationsToSendQuery,
        IEmailSender emailSender)
    {
        this.dataContextFactory = dataContextFactory;
        this.getNotificationsToSendQuery = getNotificationsToSendQuery;
        this.emailSender = emailSender;
    }

    public async Task Process()
    {
        using (var context = this.dataContextFactory.Create())
        {
            var unsentNotifications = await this.getNotificationsToSendQuery.Execute(context);
            
            foreach (var notification in unsentNotifications)
            {
                await this.emailSender.SendEmail(notification.User.Email);
            }
        }
    }
}