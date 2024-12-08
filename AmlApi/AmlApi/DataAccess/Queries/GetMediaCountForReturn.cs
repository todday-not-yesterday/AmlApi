using System.Linq;
using System.Threading.Tasks;
using AmlApi.DataAccess.Enums;
using AmlApi.DataAccess.Queries.Interfaces;
using AmlApi.Resources;
using Microsoft.EntityFrameworkCore;

namespace AmlApi.DataAccess.Queries;

public class GetMediaCountForReturn : IGetMediaCount
{
    public MediaEnquiryTypeEnum MediaEnquiryType => MediaEnquiryTypeEnum.Return;
    
    private readonly IDataContextFactory dataContextFactory;

    public GetMediaCountForReturn(IDataContextFactory dataContextFactory)
    {
        this.dataContextFactory = dataContextFactory;
    }

    public async Task<int> Get(Filters filters)
    {
        using (var context = dataContextFactory.Create())
        {
            return await context.Inventories
                .Where(x => (filters.MediaTypes == null || !filters.MediaTypes.Any() || filters.MediaTypes.Contains(x.MediaType.Key))
                            && ((filters.Branches == null || !filters.Branches.Any()) || filters.Branches.Contains(x.Branch.Key))
                            && (filters.SearchItem == null || x.Name.ToLower().Contains(filters.SearchItem.ToLower())))
                .CountAsync();
        }
    }
}