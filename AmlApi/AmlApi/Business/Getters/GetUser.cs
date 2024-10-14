namespace AmlApi.Business.Getters
{
    using System.Threading.Tasks;

    public class GetUser : IGetUser
    {
        public async Task<string> Get()
        {
            return "bob";
        }
    }
}