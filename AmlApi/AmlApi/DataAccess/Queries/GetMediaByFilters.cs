using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmlApi.DataAccess.Entities;
using AmlApi.Resources;
using Microsoft.EntityFrameworkCore;
using AmlApi.DataAccess.Queries.Interfaces;

namespace AmlApi.DataAccess.Queries;

public class GetMediaByFilters : IGetMediaByFilters
{
    private readonly IDataContextFactory _dataContextFactory;

    public GetMediaByFilters(IDataContextFactory dataContextFactory)
    {
        this._dataContextFactory = dataContextFactory;
    }

    public async Task<List<Inventory>> Get(Filters filters)
    {
        using (var context = this._dataContextFactory.Create())
        {
            return await context.Inventories
                .Include(x=>x.MediaType)
                .Include(x=>x.Branch)
                
                .Where(x => !filters.MediaTypes.Any() || filters.MediaTypes.Contains(x.MediaType.Key) 
                    && (!filters.BranchNames.Any() || filters.BranchNames.Contains(x.MediaType.Name))
                    && (!filters.MinimumPublicationYear.HasValue || 
                        (x.PublicationYear < filters.MaximumPublicationYear && x.PublicationYear > filters.MinimumPublicationYear)))
                
                .Skip(filters.PageSize * filters.PageNumber - filters.PageSize)
                .Take(filters.PageSize)
                .ToListAsync();
        }
    }
}