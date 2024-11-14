namespace AmlApi.DataAccess;

public interface IDataContextFactory
{
    IAppDbContext Create();
}