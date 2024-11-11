using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmlApi.DataAccess.Entities;
using AmlApi.Resources;
using Microsoft.EntityFrameworkCore;

namespace AmlApi.DataAccess.Queries;

public class GetMediaByFilters : IGetMediaByFilters
{
    private readonly IDataContext dataContext;

    public GetMediaByFilters(IDataContext dataContext)
    {
        this.dataContext = dataContext;
    }

    public async Task<List<Inventory>> Get(Filters filters)
    {
        using (var context = this.dataContext.Create())
        {
            return await context.Inventories
                .Include(x=>x.MediaType)
                .Include(x=>x.Branch)
                .Skip(filters.PageSize * filters.PageNumber - filters.PageSize)
                .Take(filters.PageSize)
                .ToListAsync();
        }
    }
}