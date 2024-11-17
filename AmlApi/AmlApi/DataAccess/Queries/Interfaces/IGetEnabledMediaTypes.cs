using System.Collections.Generic;
using System.Threading.Tasks;
using AmlApi.Resources;

namespace AmlApi.DataAccess.Queries.Interfaces;

public interface IGetEnabledMediaTypes
{
    Task<List<MediaTypeResource>> Get();
}