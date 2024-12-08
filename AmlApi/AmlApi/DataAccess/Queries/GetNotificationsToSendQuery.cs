using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmlApi.DataAccess.Entities;
using AmlApi.DataAccess.Queries.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AmlApi.DataAccess.Queries;

public class GetNotificationsToSendQuery : IGetNotificationsToSendQuery
{
    public async Task<List<Notification>> Execute(IAppDbContext context)
    {
        return await context.Notifications
            .Include(x => x.NotificationStatus)
            .Include(x => x.NotificationType)
            .Include(x => x.NotificationSendType)
            .Where(x => x.NotificationStatusKey == 1)
            .ToListAsync();
    }
}