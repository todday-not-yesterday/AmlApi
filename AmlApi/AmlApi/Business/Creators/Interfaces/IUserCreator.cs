using AmlApi.DataAccess.Entities;

namespace AmlApi.Business.Creators.Interfaces
{
    public interface IUserCreator
    {
        void Create(User user);
    }
}