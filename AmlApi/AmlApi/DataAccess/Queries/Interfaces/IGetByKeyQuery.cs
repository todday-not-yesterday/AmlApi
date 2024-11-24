using System.Threading.Tasks;

namespace AmlApi.DataAccess.Queries.Interfaces;

public interface IGetByKeyQuery
{
    Task<T> Get<T>(int key) where T : class, IHasKey;
    Task<T> Get<T>(int key, IAppDbContext context) where T : class, IHasKey;
}