using System.Threading.Tasks;
using AmlApi.DataAccess.Entities;

namespace AmlApi.DataAccess.Queries;

public interface IGetMediaByNameAndBranchQuery
{
    Task<Inventory> Get(IAppDbContext context, string name, int branchKey);
}