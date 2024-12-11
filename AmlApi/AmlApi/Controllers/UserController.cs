using System;
using System.Threading.Tasks;
using AmlApi.Business.Creators.Interfaces;
using AmlApi.Business.Getters.Interfaces;
using AmlApi.DataAccess.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AmlApi.Controllers;

[Route("[controller]/[action]")]
public class UserController : Controller
{
    private readonly IGetLogin getLogin;
    private readonly IUserCreator userCreator;
    private readonly IGetLevelKeyByUserKey getLevelKeyByUserKey;

    public UserController(IGetLogin getLogin,
                          IUserCreator userCreator,
                          IGetLevelKeyByUserKey getLevelKeyByUserKey)
    {
        this.getLogin = getLogin;
        this.userCreator = userCreator;
        this.getLevelKeyByUserKey = getLevelKeyByUserKey;
    }

    [HttpGet]
    public async Task<IActionResult> Login([FromQuery] string username, [FromQuery] string password)
    {
        try
        {
            return new OkObjectResult(await getLogin.Get(username, password));
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

    [HttpGet("{userKey}")]
    public async Task<IActionResult> UserIsLibraryMember(int userKey)
    {
        return new OkObjectResult(await getLevelKeyByUserKey.Get(userKey) == (int)UserLevelsEnum.LibraryMember);
    }
}