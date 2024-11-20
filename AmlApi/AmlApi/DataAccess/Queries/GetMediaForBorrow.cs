using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmlApi.DataAccess.Entities;
using AmlApi.DataAccess.Enums;
using AmlApi.DataAccess.Queries.Interfaces;
using AmlApi.Resources;
using Microsoft.EntityFrameworkCore;

namespace AmlApi.DataAccess.Queries;

public class GetMediaForBorrow : IGetFilteredMedia
{
    public MediaEnquiryTypeEnum MediaEnquiryType => MediaEnquiryTypeEnum.Borrow;
    
    private readonly IDataContextFactory dataContextFactory;

    public GetMediaForBorrow(IDataContextFactory dataContextFactory)
    {
        this.dataContextFactory = dataContextFactory;
    }

    public async Task<List<Inventory>> Get(Filters filters)
    {
        using (var context = dataContextFactory.Create())
        {
            return await context.Inventories
                .Include(x=>x.MediaType)
                .Include(x=>x.Branch)
                .Where(x => (filters.MediaTypes == null || !filters.MediaTypes.Any()) || filters.MediaTypes.Contains(x.MediaType.Key) 
                    
                    && ((filters.BranchNames == null || !filters.BranchNames.Any()) || filters.BranchNames.Contains(x.Branch.Name))
                    
                    && (!filters.MinimumPublicationYear.HasValue || 
                        (x.PublicationYear < filters.MaximumPublicationYear && x.PublicationYear > filters.MinimumPublicationYear)
                        ))
                .Skip(filters.PageSize * filters.PageNumber - filters.PageSize)
                .Take(filters.PageSize)
                .ToListAsync();
        }
    }
}