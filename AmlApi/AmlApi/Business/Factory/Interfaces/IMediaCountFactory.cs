using System.Threading.Tasks;
using AmlApi.DataAccess.Enums;
using AmlApi.DataAccess.Queries.Interfaces;

namespace AmlApi.Business.Factory.Interfaces;

public interface IMediaCountFactory
{
    Task<IGetMediaCount> GetCounter(MediaEnquiryTypeEnum mediaEnquiryTypeEnum);
}