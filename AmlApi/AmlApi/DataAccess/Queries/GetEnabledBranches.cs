using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmlApi.DataAccess.Entities;
using AmlApi.DataAccess.Queries.Interfaces;
using AmlApi.Resources;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AmlApi.DataAccess.Queries;

public class GetEnabledBranches : IGetEnabledBranches
{
    private readonly IDataContextFactory dataContextFactory;
    private readonly IMapper mapper;

    public GetEnabledBranches(IDataContextFactory dataContextFactory, IMapper mapper)
    {
        this.dataContextFactory = dataContextFactory;
        this.mapper = mapper;
    }

    public async Task<List<BranchResource>> Get()
    {
        using (var context = dataContextFactory.Create())
        {
            var branches = await context.Branches.Where(x => x.IsEnabled).ToListAsync();

            return mapper.Map<List<BranchResource>>(branches);
        }
    }
}