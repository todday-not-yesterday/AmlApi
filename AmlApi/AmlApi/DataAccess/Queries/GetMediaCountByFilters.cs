using System.Threading.Tasks;
using AmlApi.Resources;
using Microsoft.EntityFrameworkCore;
using AmlApi.DataAccess.Queries.Interfaces;

namespace AmlApi.DataAccess.Queries;

public class GetMediaCountByFilters : IGetMediaCountByFilters
{
    private readonly IDataContextFactory _dataContextFactory;

    public GetMediaCountByFilters(IDataContextFactory dataContextFactory)
    {
        this._dataContextFactory = dataContextFactory;
    }

    public async Task<int> Get(Filters filters)
    {
        using (var context = this._dataContextFactory.Create())
        {
            return await context.Inventories
                .CountAsync();
        }
    }
}