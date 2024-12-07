using System;
using System.Linq;
using System.Threading.Tasks;
using AmlApi.Business.Processor.Interfaces;
using AmlApi.DataAccess;
using AmlApi.DataAccess.Entities;
using AmlApi.DataAccess.Queries;
using AmlApi.DataAccess.Queries.Commands.Interfaces;
using AmlApi.DataAccess.Queries.Interfaces;

namespace AmlApi.Business.Processor;

public class OverdueMediaProcessor : IOverdueMediaProcessor
{
    private readonly IDataContextFactory dataContextFactory;
    private readonly IGetOverdueMediaQuery getOverdueMediaQuery;
    private readonly IInsertEntityCommand insertEntityCommand;

    public OverdueMediaProcessor(IGetOverdueMediaQuery getOverdueMediaQuery,
        IDataContextFactory dataContextFactory)
    {
        this.getOverdueMediaQuery = getOverdueMediaQuery;
        this.dataContextFactory = dataContextFactory;
    }

    public async Task Process()
    {
        using (var context = this.dataContextFactory.Create())
        {
            var overdueMedia = await this.getOverdueMediaQuery.Execute(context);

            var overdueNotifications = overdueMedia.Select(x => new Notification
            {
                UserKey = x.UserKey,
                NotificationTypeKey = 2,
                NotificationStatusKey = 1,
                AddedDate = DateTime.Today,
                SendAt = DateTime.Today,
                SendTypeKey = 1
            });

            foreach (var notification in overdueNotifications)
            {
                await this.insertEntityCommand.Execute(notification);
            }
        }
    }
}