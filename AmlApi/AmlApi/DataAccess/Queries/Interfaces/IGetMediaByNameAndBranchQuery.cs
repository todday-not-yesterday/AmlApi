using System.Threading.Tasks;
using AmlApi.DataAccess.Entities;

namespace AmlApi.DataAccess.Queries.Interfaces;

public interface IGetMediaByNameAndBranchQuery
{
    Task<Inventory> Execute(IAppDbContext context, string name, int branchKey);
}