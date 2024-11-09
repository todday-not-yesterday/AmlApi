using System;
using System.Threading.Tasks;
using AmlApi.DataAccess.Queries;
using Microsoft.AspNetCore.Mvc;

namespace AmlApi.Controllers;

[Route("[controller]")]
public class SearchController : Controller
{
    private readonly IGetAllMediaByPage getAllMediaByPage;

    public SearchController(IGetAllMediaByPage getAllMediaByPage)
    {
        this.getAllMediaByPage = getAllMediaByPage;
    }

    [HttpPost("[action]/pageNumber/pageSize")]
    public async Task<IActionResult> GetAllMedia(int pageNumber, int pageSize)
    {
        try
        {
            return new OkObjectResult(await getAllMediaByPage.Get(pageNumber, pageSize));
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