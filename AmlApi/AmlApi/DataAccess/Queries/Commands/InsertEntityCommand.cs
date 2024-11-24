using System.Threading.Tasks;
using AmlApi.DataAccess.Queries.Commands.Interfaces;

namespace AmlApi.DataAccess.Queries.Commands;

public class InsertEntityCommand : IInsertEntityCommand
{
    private readonly IDataContextFactory dataContextFactory;

    public InsertEntityCommand(IDataContextFactory dataContextFactory)
    {
        this.dataContextFactory = dataContextFactory;
    }

    public async Task Execute<T>(T entity) where T : class
    {
        using var context = dataContextFactory.Create();
        await context.Set<T>().AddAsync(entity);
        await context.SaveChangesAsync();
    }
    
    public async Task Execute<T>(T entity, IAppDbContext context) where T : class
    {
        await context.Set<T>().AddAsync(entity);
        await context.SaveChangesAsync();
    }
}