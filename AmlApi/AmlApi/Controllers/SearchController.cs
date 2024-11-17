using System;
using System.Threading.Tasks;
using AmlApi.Business;
using AmlApi.DataAccess.Queries.Interfaces;
using AmlApi.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace AmlApi.Controllers;

[Route("[controller]")]
public class SearchController : Controller
{
    private readonly IGetMappedMediaByFilters getMappedMediaByFilters;
    private readonly IGetEnabledMediaTypes getEnabledMediaTypes;
    private readonly IGetEnabledBranches getEnabledBranches;

    public SearchController(IGetMappedMediaByFilters getMappedMediaByFilters, 
        IGetEnabledMediaTypes getEnabledMediaTypes, 
        IGetEnabledBranches getEnabledBranches)
    {
        this.getMappedMediaByFilters = getMappedMediaByFilters;
        this.getEnabledMediaTypes = getEnabledMediaTypes;
        this.getEnabledBranches = getEnabledBranches;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetMedia([FromBody] Filters filters)
    {
        try
        {
            return new OkObjectResult(await getMappedMediaByFilters.Get(filters));
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }
    
    [HttpGet("[action]")]
    public async Task<IActionResult> GetMediaTypes()
    {
        try
        {
            return new OkObjectResult(await getEnabledMediaTypes.Get());
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }
    
    [HttpGet("[action]")]
    public async Task<IActionResult> GetBranches()
    {
        try
        {
            return new OkObjectResult(await getEnabledBranches.Get());
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }
}