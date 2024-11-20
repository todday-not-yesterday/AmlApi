using System.Threading.Tasks;
using AmlApi.Business;
using AmlApi.DataAccess.Enums;
using AmlApi.DataAccess.Queries.Interfaces;

namespace AmlApi.Factory.Interfaces;

public interface IFilteredMediaFactory
{
    Task<IGetFilteredMedia> GetFilter(MediaEnquiryTypeEnum mediaEnquiryTypeEnum);
}