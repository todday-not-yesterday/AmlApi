using System.Threading.Tasks;

namespace AmlApi.Business.Getters.Interfaces
{
    public interface IGetLogin
    {
        Task<int?> Get(string username, string password);
    }
}