using System.Threading.Tasks;
using AmlApi.Resources;

namespace AmlApi.Business.Getters.Interfaces;

public interface IGetMappedMediaByFilters
{
    Task<GetMediaResponse> Get(Filters filters);
}