using System.Collections.Generic;
using System.Threading.Tasks;
using AmlApi.DataAccess.Entities;
using AmlApi.DataAccess.Enums;
using AmlApi.DataAccess.Queries.Interfaces;
using AmlApi.Resources;
using AutoMapper;

namespace AmlApi.Business;

public class GetMappedMediaByFilters : IGetMappedMediaByFilters
{
    private readonly IGetMediaByFilters getMediaByFilters;
    private readonly IGetMediaCountByFilters getMediaCountByFilters;
    private readonly IMapper mapper;

    public GetMappedMediaByFilters(IGetMediaByFilters getMediaByFilters,
        IGetMediaCountByFilters getMediaCountByFilters,
        IMapper mapper)
    {
        this.getMediaByFilters = getMediaByFilters;
        this.getMediaCountByFilters = getMediaCountByFilters;
        this.mapper = mapper;
    }

    public async Task<GetMediaResponse> Get(Filters filters)
    {
        var media = new List<Inventory>();
        if (filters.MediaEnquiryType == MediaEnquiryTypeEnum.Return)
        {
            // return media that the customer has
        }
        else
        {
            media = await getMediaByFilters.Get(filters);
        }

        var mediaCount = await getMediaCountByFilters.Get(filters);

        return new GetMediaResponse
        {
            MediaResources = mapper.Map<List<MediaResource>>(media),
            MediaCount = mediaCount
        };
    }
}