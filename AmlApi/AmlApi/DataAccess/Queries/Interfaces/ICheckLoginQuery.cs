using System.Threading.Tasks;

namespace AmlApi.DataAccess.Queries.Interfaces
{
    public interface ICheckLoginQuery
    {
        Task<int?> Get(string UserName, string Password);
    }
}