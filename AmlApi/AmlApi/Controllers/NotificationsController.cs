using System;
using System.Threading.Tasks;
using AmlApi.Business.Getters;
using AmlApi.Business.Getters.Interfaces;
using AmlApi.Business.Processor;
using AmlApi.Business.Processor.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AmlApi.Controllers;

[Route("[controller]/[action]")]
public class NotificationsController : Controller
{
    private readonly INotificationsGetter notificationsGetter;
    private readonly INotificationsToSendProcessor notificationsToSendProcessor;
    private readonly IOverdueMediaProcessor overdueMediaProcessor;

    public NotificationsController(
        INotificationsGetter notificationsGetter,
        INotificationsToSendProcessor notificationsToSendProcessor,
        IOverdueMediaProcessor overdueMediaProcessor)
    {
        this.notificationsGetter = notificationsGetter;
        this.notificationsToSendProcessor = notificationsToSendProcessor;
        this.overdueMediaProcessor = overdueMediaProcessor;
    }

    [HttpPost("{userKey}")]
    public async Task<IActionResult> GetNotificationsForUser(int userKey)
    {
        try
        {
            var result = await this.notificationsGetter.Get(userKey);
            
            return new OkObjectResult(result);
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> PollForNotificationsToSend()
    {
        try
        {
            //would normally be triggered by an hourly message published to a que
            await this.notificationsToSendProcessor.Process();

            return Ok();
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> PollForOverdueMedia()
    {
        try
        {
            //would normally be triggered by an hourly message published to a que
            await this.overdueMediaProcessor.Process();

            return Ok();
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }
}