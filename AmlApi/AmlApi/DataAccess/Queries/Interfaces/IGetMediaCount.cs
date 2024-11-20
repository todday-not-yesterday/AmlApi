using System.Threading.Tasks;
using AmlApi.DataAccess.Enums;
using AmlApi.Resources;

namespace AmlApi.DataAccess.Queries.Interfaces;

public interface IGetMediaCount
{
    Task<int> Get(Filters filters);
    MediaEnquiryTypeEnum MediaEnquiryType { get; }
}