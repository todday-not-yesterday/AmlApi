using System.Collections.Generic;
using System.Threading.Tasks;
using AmlApi.DataAccess.Entities;
using AmlApi.DataAccess.Enums;
using AmlApi.DataAccess.Queries.Interfaces;
using AmlApi.Resources;

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
            return null;
        }
    }
}