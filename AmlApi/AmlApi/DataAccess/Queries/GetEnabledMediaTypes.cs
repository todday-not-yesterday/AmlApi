using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmlApi.DataAccess.Queries.Interfaces;
using AmlApi.Resources;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AmlApi.DataAccess.Queries;

public class GetEnabledMediaTypes : IGetEnabledMediaTypes
{
    private readonly IDataContextFactory dataContextFactory;
    private readonly IMapper mapper;

    public GetEnabledMediaTypes(IDataContextFactory dataContextFactory, IMapper mapper)
    {
        this.dataContextFactory = dataContextFactory;
        this.mapper = mapper;
    }

    public async Task<List<MediaTypeResource>> Get()
    {
        using (var context = dataContextFactory.Create())
        {
            var mediaTypes = await context.MediaTypes.Where(x => x.IsEnabled).ToListAsync();

            return mapper.Map<List<MediaTypeResource>>(mediaTypes);
        }
    }
}