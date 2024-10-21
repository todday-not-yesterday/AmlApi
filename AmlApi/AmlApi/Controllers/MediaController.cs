using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AmlApi.Controllers;

[Route("[controller]")]
public class MediaController : Controller
{
    //just some ideas of controllers i did cos bored
    [HttpPost("BorrowMedia/{mediaKey}")]
    public async Task<IActionResult> BorrowMedia(int mediaKey)
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
    
    [HttpPost("ReturnMedia/{mediaKey}")]
    public async Task<IActionResult> ReturnMedia(int mediaKey)
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