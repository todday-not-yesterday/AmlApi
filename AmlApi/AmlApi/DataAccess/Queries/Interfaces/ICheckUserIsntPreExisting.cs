using AmlApi.DataAccess.Entities;
using System.Threading.Tasks;

namespace AmlApi.DataAccess.Queries.Interfaces
{
    public interface ICheckUserIsntPreExisting
    {
        bool UserExists(User user);
    }
}