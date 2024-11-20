using System.Collections.Generic;
using System.Threading.Tasks;
using AmlApi.Business.Getters.Interfaces;
using AmlApi.DataAccess.Queries.Interfaces;
using AmlApi.Factory.Interfaces;
using AmlApi.Resources;
using AutoMapper;

namespace AmlApi.Business;

public class GetMappedMediaByFilters : IGetMappedMediaByFilters
{
    private readonly IFilteredMediaFactory filteredMediaFactory;
    private readonly IMediaCountFactory mediaCountFactory;
    private readonly IMapper mapper;

    public GetMappedMediaByFilters(IFilteredMediaFactory filteredMediaFactory,
        IMediaCountFactory mediaCountFactory,
        IMapper mapper)
    {
        this.filteredMediaFactory = filteredMediaFactory;
        this.mediaCountFactory = mediaCountFactory;
        this.mapper = mapper;
    }

    public async Task<GetMediaResponse> Get(Filters filters)
    {
        var filter = await filteredMediaFactory.GetFilter(filters.MediaEnquiryType);
        var media = await filter.Get(filters);
        
        var counter = await mediaCountFactory.GetCounter(filters.MediaEnquiryType);
        var mediaCount = await counter.Get(filters);

        return new GetMediaResponse
        {
            MediaResources = mapper.Map<List<MediaResource>>(media),
            MediaCount = mediaCount
        };
    }
}