using System.Collections.Generic;
using System.Threading.Tasks;
using AmlApi.DataAccess.Entities;

namespace AmlApi.DataAccess.Queries.Interfaces;

public interface IGetNotificationsByUserKeyQuery
{
    Task<List<Notification>> Execute(IAppDbContext context, int userkey);
}