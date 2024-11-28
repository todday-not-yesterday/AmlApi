using System;
using System.Threading.Tasks;
using AmlApi.Business.Processor;
using AmlApi.Resources;
using Microsoft.AspNetCore.Mvc;

namespace AmlApi.Controllers;

[Route("[controller]")]
public class InventoryController : Controller
{
    private readonly ITransferDataProcessor transferDataProcessor;

    public InventoryController(ITransferDataProcessor transferDataProcessor)
    {
        this.transferDataProcessor = transferDataProcessor;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> TransferMedia([FromBody] TransferData transferData)
    {
        try
        {
            var result = await this.transferDataProcessor.Process(transferData);
            
            return new OkObjectResult(result);
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }
}