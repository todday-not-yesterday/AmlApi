using System.Collections.Generic;
using System.Threading.Tasks;
using AmlApi.DataAccess.Entities;

namespace AmlApi.DataAccess.Queries.Interfaces;

public interface IGetOverdueMediaQuery
{
    Task<List<UserInventory>> Execute(IAppDbContext context);
}