using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmlApi.DataAccess.Entities;
using AmlApi.DataAccess.Enums;
using AmlApi.DataAccess.Queries.Interfaces;
using AmlApi.Resources;
using Microsoft.EntityFrameworkCore;

namespace AmlApi.DataAccess.Queries;

public class GetMediaForManageInventory : IGetFilteredMedia
{
    public MediaEnquiryTypeEnum MediaEnquiryType => MediaEnquiryTypeEnum.ManageInventory;
    
    private readonly IDataContextFactory dataContextFactory;

    public GetMediaForManageInventory(IDataContextFactory dataContextFactory)
    {
        this.dataContextFactory = dataContextFactory;
    }

    public async Task<List<Inventory>> Get(Filters filters)
    {
        using (var context = dataContextFactory.Create())
        {
            if (filters.Branches.Any())
            {
                return await context.Inventories
                    .Include(x=> x.MediaType)
                    .Include(x=> x.Branch)
                    .Where(x => filters.Branches.Contains(x.BranchKey))
                    .Skip(filters.PageSize * filters.PageNumber - filters.PageSize)
                    .Take(filters.PageSize)
                    .ToListAsync();
            }
            
            if (filters.MediaTypes.Any())
            {
                return await context.Inventories
                    .Include(x=> x.MediaType)
                    .Include(x=> x.Branch)
                    .Where(x => filters.MediaTypes.Contains(x.MediaTypeKey))
                    .Skip(filters.PageSize * filters.PageNumber - filters.PageSize)
                    .Take(filters.PageSize)
                    .ToListAsync();
            }
            
            if (filters.SearchItem != null)
            {
                return await context.Inventories
                    .Include(x=> x.MediaType)
                    .Include(x=> x.Branch)
                    .Where(x => x.Name.ToLower().Contains(filters.SearchItem.ToLower()))
                    .Skip(filters.PageSize * filters.PageNumber - filters.PageSize)
                    .Take(filters.PageSize)
                    .ToListAsync();
            }
            
            if (filters.PublicationYear != null)
            {
                return await context.Inventories
                    .Include(x=> x.MediaType)
                    .Include(x=> x.Branch)
                    .Where(x => x.PublicationYear == filters.PublicationYear)
                    .Skip(filters.PageSize * filters.PageNumber - filters.PageSize)
                    .Take(filters.PageSize)
                    .ToListAsync();
            }
            
            return await context.Inventories
                .Include(x=>x.MediaType)
                .Include(x=>x.Branch)
                .Skip(filters.PageSize * filters.PageNumber - filters.PageSize)
                .Take(filters.PageSize)
                .ToListAsync();
        }
    }
}