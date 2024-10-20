namespace AmlApi.DataAccess;

public interface IDataContext
{
    IAppDbContext Create();
}