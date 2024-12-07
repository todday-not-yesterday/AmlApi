using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmlApi.DataAccess.Entities;
using AmlApi.DataAccess.Queries.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AmlApi.DataAccess.Queries;

public class GetOverdueMediaQuery : IGetOverdueMediaQuery
{
    public async Task<List<UserInventory>> Execute(IAppDbContext context)
    {
        return await context.UserInventories
            .Where(x => x.ReturnDate < DateTime.Today && x.StatusKey == 1)
            .ToListAsync();
    }
}