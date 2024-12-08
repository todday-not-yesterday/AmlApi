using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmlApi.Business.Getters.Interfaces;
using AmlApi.DataAccess;
using AmlApi.DataAccess.Queries;
using AmlApi.DataAccess.Queries.Interfaces;
using AmlApi.Resources;

namespace AmlApi.Business.Getters;

public class NotificationsGetter : INotificationsGetter
{
    private readonly IDataContextFactory dataContextFactory;
    private readonly IGetNotificationsByUserKeyQuery getNotificationsByUserKeyQuery;

    public NotificationsGetter(
        IDataContextFactory dataContextFactory,
        IGetNotificationsByUserKeyQuery getNotificationsByUserKeyQuery)
    {
        this.dataContextFactory = dataContextFactory;
        this.getNotificationsByUserKeyQuery = getNotificationsByUserKeyQuery;
    }

    public async Task<List<NotificationsResponse>> Get(int userKey)
    {
        using (var context = this.dataContextFactory.Create())
        {
            var notifications = await this.getNotificationsByUserKeyQuery.Execute(context, userKey);

            return notifications.Select(x => new NotificationsResponse
            {
                Key = x.Key,
                UserKey = x.UserKey,
                NotificationType = x.NotificationType.Type,
                NotificationStatus = x.NotificationStatus.Status,
                AddedDate = x.AddedDate,
                SendAt = x.SendAt,
                NotificationSendType = x.NotificationSendType.Type
            }).ToList();
        }
    }
}