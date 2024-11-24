using System.Linq;
using System.Threading.Tasks;
using AmlApi.DataAccess.Queries.Interfaces;

namespace AmlApi.DataAccess.Queries;

public class GetByKeyQuery : IGetByKeyQuery
{
    private readonly IDataContextFactory dataContextFactory;

    public GetByKeyQuery(IDataContextFactory dataContextFactory)
    {
        this.dataContextFactory = dataContextFactory;
    }

    public Task<T?> Get<T>(int key) where T : class, IHasKey
    {
        using var context = dataContextFactory.Create();
        return Task.FromResult(context.Set<T>().FirstOrDefault(x => x.Key == key));
    }
    
    public Task<T?> Get<T>(int key, IAppDbContext context) where T : class, IHasKey
    {
        return Task.FromResult(context.Set<T>().FirstOrDefault(x => x.Key == key));
    }
}