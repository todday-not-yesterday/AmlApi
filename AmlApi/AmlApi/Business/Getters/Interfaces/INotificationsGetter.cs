using System.Collections.Generic;
using System.Threading.Tasks;
using AmlApi.Resources;

namespace AmlApi.Business.Getters.Interfaces;

public interface INotificationsGetter
{
    Task<List<NotificationsResponse>> Get(int userKey);
}