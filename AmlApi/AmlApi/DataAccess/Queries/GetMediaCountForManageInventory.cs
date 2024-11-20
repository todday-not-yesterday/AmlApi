using System.Threading.Tasks;
using AmlApi.DataAccess.Enums;
using AmlApi.DataAccess.Queries.Interfaces;
using AmlApi.Resources;

namespace AmlApi.DataAccess.Queries;

public class GetMediaCountForManageInventory : IGetMediaCount
{
    public MediaEnquiryTypeEnum MediaEnquiryType => MediaEnquiryTypeEnum.ManageInventory;
    
    private readonly IDataContextFactory dataContextFactory;

    public GetMediaCountForManageInventory(IDataContextFactory dataContextFactory)
    {
        this.dataContextFactory = dataContextFactory;
    }

    public async Task<int> Get(Filters filters)
    {
        using (var context = dataContextFactory.Create())
        {
            return 0;
        }
    }
}