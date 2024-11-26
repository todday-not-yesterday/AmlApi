using System;
using System.Threading.Tasks;
using AmlApi.Business.Getters.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AmlApi.Controllers;

[Route("[controller]/[action]")]
public class UserController : Controller
{
    private readonly IGetLogin getLogin;

    public UserController(IGetLogin getLogin)
    {
        this.getLogin = getLogin;
    }

    [HttpGet]
    public async Task<IActionResult> Login([FromQuery] string username, [FromQuery] string password)
    {
        try
        {
            var result = await getLogin.Get(username, password);

            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}