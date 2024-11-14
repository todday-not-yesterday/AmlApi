using System.Threading.Tasks;
using AmlApi.Resources;

namespace AmlApi.DataAccess.Queries.Interfaces;

public interface IGetMediaCountByFilters
{
    Task<int> Get(Filters filters);
}