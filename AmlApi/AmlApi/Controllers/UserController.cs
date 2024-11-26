using System;
using System.Threading.Tasks;
using AmlApi.Business.Creators.Interfaces;
using AmlApi.Business.Getters.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AmlApi.Controllers;

[Route("[controller]/[action]")]
public class UserController : Controller
{
    private readonly IGetLogin getLogin;
    private readonly IUserCreator userCreator;

    public UserController(IGetLogin getLogin,
                          IUserCreator userCreator)
    {
        this.getLogin = getLogin;
        this.userCreator = userCreator;
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

    [HttpPost]
    public IActionResult Register([FromBody] DataAccess.Entities.User user)
    {
        try
        {
            userCreator.Create(user);

            return Ok(new { message = "Registration successful" });
        }
        catch (Exception e)
        {
            return BadRequest(new { error = e.Message });
        }
    }


}