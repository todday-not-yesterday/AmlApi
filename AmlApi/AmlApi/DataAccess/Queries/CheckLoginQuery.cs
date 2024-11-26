using System;
using System.Linq;
using System.Threading.Tasks;
using AmlApi.DataAccess.Queries.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AmlApi.DataAccess.Queries;

public class CheckLoginQuery : ICheckLoginQuery
{

    private readonly IDataContextFactory dataContextFactory;

    public CheckLoginQuery(IDataContextFactory dataContextFactory)
    {
        this.dataContextFactory = dataContextFactory;
    }

    public async Task<int?> Get(string UserName, string Password)
    {
        using (var context = dataContextFactory.Create())
        {
            return await context.Users
                .Where(x => x.UserName == UserName && x.Password == Password)
            .Select(x => x.Key)
            .FirstOrDefaultAsync();
        }
    }
}