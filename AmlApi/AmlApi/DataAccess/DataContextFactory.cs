using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AmlApi.DataAccess;

public class DataContextFactory : IDataContextFactory
{
    private readonly IConfiguration configuration;

    public DataContextFactory(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public IAppDbContext Create()
    {
        var contextOptionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        contextOptionsBuilder.UseNpgsql(this.configuration.GetConnectionString("AmlDb"));
        return new AppDbContext(contextOptionsBuilder.Options);
    }
}