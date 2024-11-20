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
            return await context.Inventories
                .Where(x => (filters.MediaTypes == null || !filters.MediaTypes.Any()) || filters.MediaTypes.Contains(x.MediaType.Key) 
                    
                    && ((filters.BranchNames == null || !filters.BranchNames.Any()) || filters.BranchNames.Contains(x.Branch.Name))
                    
                    && (!filters.MinimumPublicationYear.HasValue || 
                        (x.PublicationYear < filters.MaximumPublicationYear && x.PublicationYear > filters.MinimumPublicationYear)
                    ))
                .CountAsync();
        }
    }
}