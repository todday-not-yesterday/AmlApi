namespace AmlApi.Business.Getters
{
    using System.Threading.Tasks;

    public interface IGetUser
    {
        Task<string> Get();
    }
}