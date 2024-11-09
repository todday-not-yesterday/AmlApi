using System.Collections.Generic;
using System.Threading.Tasks;
using AmlApi.DataAccess.Entities;

namespace AmlApi.DataAccess.Queries;

public interface IGetAllMediaByPage
{
    Task<List<Inventory>> Get(int pageNumber, int pageSize);
}