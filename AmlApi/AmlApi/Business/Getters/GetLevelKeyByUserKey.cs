using System.Threading.Tasks;
using AmlApi.Business.Getters.Interfaces;
using AmlApi.DataAccess.Entities;
using AmlApi.DataAccess.Queries.Interfaces;

namespace AmlApi.Business.Getters;

public class GetLevelKeyByUserKey : IGetLevelKeyByUserKey
{
    private readonly IGetByKeyQuery getByKeyQuery;

    public GetLevelKeyByUserKey(IGetByKeyQuery getByKeyQuery)
    {
        this.getByKeyQuery = getByKeyQuery;
    }

    public async Task<int?> Get(int userKey)
    {
        return getByKeyQuery.Get<User>(userKey).Result.UserLevel;
    }
}