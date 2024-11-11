using System.Threading.Tasks;
using AmlApi.Resources;
using Microsoft.EntityFrameworkCore;

namespace AmlApi.DataAccess.Queries;

public class GetMediaCountByFilters : IGetMediaCountByFilters
{
    private readonly IDataContext dataContext;

    public GetMediaCountByFilters(IDataContext dataContext)
    {
        this.dataContext = dataContext;
    }

    public async Task<int> Get(Filters filters)
    {
        using (var context = this.dataContext.Create())
        {
            return await context.Inventories
                .CountAsync();
        }
    }
}