﻿using System.Threading.Tasks;
using AmlApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AmlApi.DataAccess.Queries;

public class GetMediaByNameAndBranchQuery : IGetMediaByNameAndBranchQuery
{
    public async Task<Inventory> Get(IAppDbContext context, string name, int branchKey)
    {
        return await context.Inventories.FirstOrDefaultAsync(x => name.Contains(x.Name) && x.BranchKey == branchKey);
    }
}