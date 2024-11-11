using System;
using System.Threading.Tasks;
using AmlApi.Business;
using AmlApi.Resources;
using Microsoft.AspNetCore.Mvc;

namespace AmlApi.Controllers;

[Route("[controller]")]
public class SearchController : Controller
{
    private readonly IGetMappedMediaByFilters getMappedMediaByFilters;

    public SearchController(IGetMappedMediaByFilters getMappedMediaByFilters)
    {
        this.getMappedMediaByFilters = getMappedMediaByFilters;
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
    
    // [HttpPost("GetFilteredMedia/{filters}")]
    // public async Task<IActionResult> GetAllMedia(Filters filters)
    // {
    //     try
    //     {
    //         return new OkObjectResult("sommet");
    //     }
    //     catch (Exception e)
    //     {
    //         return new BadRequestObjectResult(e.Message);
    //     }
    // }
}