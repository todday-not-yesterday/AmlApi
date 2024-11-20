using System.Collections.Generic;
using System.Threading.Tasks;
using AmlApi.DataAccess.Entities;
using AmlApi.DataAccess.Enums;
using AmlApi.DataAccess.Queries.Interfaces;
using AmlApi.Resources;

namespace AmlApi.DataAccess.Queries;

public class GetMediaForReturn : IGetFilteredMedia
{
    public MediaEnquiryTypeEnum MediaEnquiryType => MediaEnquiryTypeEnum.Return;
    
    private readonly IDataContextFactory dataContextFactory;

    public GetMediaForReturn(IDataContextFactory dataContextFactory)
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