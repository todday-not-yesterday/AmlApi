using System.Threading.Tasks;

namespace AmlApi.Business.Getters.Interfaces
{
    public interface IGetLogin
    {
        Task<bool> Get(string Username, string password);
    }
}