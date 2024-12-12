using System.Threading.Tasks;
using AmlApi.Resources;
using System.Linq;
using AmlApi.DataAccess.Enums;
using AmlApi.DataAccess.Queries.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AmlApi.DataAccess.Queries;

public class GetMediaCountForBorrow : IGetMediaCount
{
    public MediaEnquiryTypeEnum MediaEnquiryType => MediaEnquiryTypeEnum.Borrow;
    
    private readonly IDataContextFactory dataContextFactory;

    public GetMediaCountForBorrow(IDataContextFactory dataContextFactory)
    {
        this.dataContextFactory = dataContextFactory;
    }

    public async Task<int> Get(Filters filters)
    {
        using (var context = dataContextFactory.Create())
        {
            var userExistingMedia = context.UserInventories.Where(x => x.UserKey == filters.UserKey)
                .Select(x => x.Inventory).Distinct();

            return await context.Inventories
                .Where(x => (filters.MediaTypes == null || !filters.MediaTypes.Any() || filters.MediaTypes.Contains(x.MediaType.Key))
                            && ((filters.Branches == null || !filters.Branches.Any()) || filters.Branches.Contains(x.Branch.Key))
                            && (filters.SearchItem == null || x.Name.ToLower().Contains(filters.SearchItem.ToLower()))
                            && !userExistingMedia.Any(y=> y.Key == x.Key))
                .CountAsync();
        }
    }
}