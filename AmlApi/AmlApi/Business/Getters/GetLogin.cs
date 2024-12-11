using System.Threading.Tasks;
using AmlApi.Business.Getters.Interfaces;
using AmlApi.DataAccess.Queries.Interfaces;

namespace AmlApi.Business.Getters;

public class GetLogin : IGetLogin
{
    private readonly ICheckLoginQuery checkLoginQuery;

    public GetLogin(ICheckLoginQuery checkLoginQuery)
    {
        this.checkLoginQuery = checkLoginQuery;
    }

    public async Task<int?> Get(string username, string password)
    {
        return await checkLoginQuery.Get(username, password);
    }
}