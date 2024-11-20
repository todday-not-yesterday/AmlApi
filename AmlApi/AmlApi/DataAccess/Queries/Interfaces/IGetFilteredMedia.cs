using System.Collections.Generic;
using System.Threading.Tasks;
using AmlApi.DataAccess.Entities;
using AmlApi.DataAccess.Enums;
using AmlApi.Resources;

namespace AmlApi.DataAccess.Queries.Interfaces;

public interface IGetFilteredMedia
{
    Task<List<Inventory>> Get(Filters filters);
    MediaEnquiryTypeEnum MediaEnquiryType { get; }
}