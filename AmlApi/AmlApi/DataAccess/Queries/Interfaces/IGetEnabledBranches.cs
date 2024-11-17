using System.Collections.Generic;
using System.Threading.Tasks;
using AmlApi.Resources;

namespace AmlApi.DataAccess.Queries.Interfaces;

public interface IGetEnabledBranches
{
    Task<List<BranchResource>> Get();
}