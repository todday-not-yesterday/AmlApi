using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmlApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AmlApi.DataAccess.Queries;

public class GetAllMediaByPage : IGetAllMediaByPage
{
    private readonly IDataContext dataContext;

    public GetAllMediaByPage(IDataContext dataContext)
    {
        this.dataContext = dataContext;
    }

    public async Task<List<Inventory>> Get(int pageNumber, int pageSize)
    {
        using (var context = this.dataContext.Create())
        {
            return await context.Inventories
                .Include(x=>x.MediaType)
                .Include(x=>x.Branch)
                .Skip(pageSize * pageNumber)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}