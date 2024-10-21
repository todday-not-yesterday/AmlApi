using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AmlApi.Controllers;

[Route("[controller]")]
public class SearchController : Controller
{
    //just some ideas of controllers i did cos bored
    [HttpPost("GetAllMedia")]
    public async Task<IActionResult> GetAllMedia()
    {
        try
        {
            return new OkObjectResult("sommet");
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }
    
    [HttpPost("GetFilteredMedia/{filters}")]
    public async Task<IActionResult> GetAllMedia(Filters filters)
    {
        try
        {
            return new OkObjectResult("sommet");
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }
}