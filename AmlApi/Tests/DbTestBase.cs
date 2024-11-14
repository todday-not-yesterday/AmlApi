using AmlApi.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Tests;

public class DbTestBase<T> : TestBase<T> where T : class
{
    private readonly IServiceProvider serviceProvider;

    protected readonly IAppDbContext appDbContext;

    public DbTestBase()
    {
        this.serviceProvider = new ServiceCollection()
            .AddEntityFrameworkNpgsql()
            .BuildServiceProvider();

        this.appDbContext = this.CreateAppDataContext();

        this.AutoMocker.GetMock<IDataContextFactory>()
            .Setup(x => x.Create())
            .Returns(this.appDbContext);
    }

    public IAppDbContext CreateAppDataContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("MockDb")
            .UseInternalServiceProvider(this.serviceProvider)
            .Options;

        return new AppDbContext(options);
    }
    
}