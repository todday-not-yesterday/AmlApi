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

    public async Task<bool> Get(string Username, string password)
    {
        var success = await checkLoginQuery.Get(Username, password);

        if (success == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}