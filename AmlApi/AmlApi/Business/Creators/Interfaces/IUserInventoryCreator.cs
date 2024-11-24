using AmlApi.DataAccess;

namespace AmlApi.Business.Creators.Interfaces;

public interface IUserInventoryCreator
{
    void Create(int mediaKey, int userKey);
}