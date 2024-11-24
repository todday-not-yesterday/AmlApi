using System.Threading.Tasks;
using AmlApi.DataAccess.Queries.Commands.Interfaces;

namespace AmlApi.DataAccess.Queries.Commands;

public class UpdateEntityCommand : IUpdateEntityCommand
{
    private readonly IDataContextFactory dataContextFactory;

    public UpdateEntityCommand(IDataContextFactory dataContextFactory)
    {
        this.dataContextFactory = dataContextFactory;
    }

    public async Task Execute<T>(T entity) where T : class
    {
        using var context = dataContextFactory.Create();
        context.Set<T>().Update(entity);
        await context.SaveChangesAsync();
    }
    
    public async Task Execute<T>(T entity, IAppDbContext context) where T : class
    {
        context.Set<T>().Update(entity);
        await context.SaveChangesAsync();
    }
}