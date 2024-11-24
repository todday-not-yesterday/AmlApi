using System;
using System.Threading.Tasks;
using AmlApi.Business;
using AmlApi.Business.Processor;
using AmlApi.Business.Processor.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AmlApi.Controllers;

[Route("[controller]/[action]")]
public class MediaController : Controller
{
    private readonly IMediaBorrowProcessor _mediaBorrowProcessor;

    public MediaController(IMediaBorrowProcessor mediaBorrowProcessor)
    {
        this._mediaBorrowProcessor = mediaBorrowProcessor;
    }

    [HttpPost("{mediaKey}/{userKey}")]
    public async Task<IActionResult> BorrowMedia(int mediaKey, int userKey)
    {
        try
        {
            return new OkObjectResult(await _mediaBorrowProcessor.Borrow(mediaKey, userKey));
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