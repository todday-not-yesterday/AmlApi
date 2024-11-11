using System.Collections.Generic;
using System.Threading.Tasks;
using AmlApi.DataAccess.Queries;
using AmlApi.Resources;
using AutoMapper;

namespace AmlApi.Business;

public class GetMappedMediaByFilters : IGetMappedMediaByFilters
{
    private readonly IGetMediaByFilters getMediaByFilters;
    private readonly IMapper mapper;

    public GetMappedMediaByFilters(IGetMediaByFilters getMediaByFilters, IMapper mapper)
    {
        this.getMediaByFilters = getMediaByFilters;
        this.mapper = mapper;
    }

    public async Task<List<MediaResource>> Get(Filters filters)
    {
        var media = await getMediaByFilters.Get(filters);

        return mapper.Map<List<MediaResource>>(media);
    }
}