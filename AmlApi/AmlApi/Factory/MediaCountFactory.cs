using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmlApi.DataAccess.Enums;
using AmlApi.DataAccess.Queries.Interfaces;
using AmlApi.Factory.Interfaces;

namespace AmlApi.Factory;

public class MediaCountFactory : IMediaCountFactory
{
    private readonly IList<IGetMediaCount> getFilteredMedia;

    public MediaCountFactory(IList<IGetMediaCount> getFilteredMedia)
    {
        this.getFilteredMedia = getFilteredMedia;
    }

    public async Task<IGetMediaCount> GetCounter(MediaEnquiryTypeEnum mediaEnquiryTypeEnum)
    {
        return this.getFilteredMedia.FirstOrDefault(x => x.MediaEnquiryType == mediaEnquiryTypeEnum);
    }
}