using System.Threading.Tasks;

namespace AmlApi.Business.Getters.Interfaces;

public interface IGetLevelKeyByUserKey
{
    Task<int?> Get(int userKey);
}