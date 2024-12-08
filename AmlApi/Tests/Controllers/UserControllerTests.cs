using AmlApi.Business.Creators.Interfaces;
using AmlApi.Business.Getters.Interfaces;
using AmlApi.Controllers;
using AmlApi.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Tests.Controllers;

public class UserControllerTests : DbTestBase<UserController>
{
    [Fact]
    public async void Login()
    {
        var stubUsername = "user";
        var stubPassword = "password";


        this.AutoMocker.GetMock<IGetLogin>()
            .Setup(x => x.Get(stubUsername, stubPassword));

        var sut = this.CreateTestSubject();
        var result = await sut.Login(stubUsername, stubPassword) as OkObjectResult;

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void Register()
    {
        var stubUser = new User { };

        this.AutoMocker.GetMock<IUserCreator>()
            .Setup(x => x.Create(stubUser));

        var sut = this.CreateTestSubject();
        var result = sut.Register(stubUser) as OkObjectResult;

        Assert.IsType<OkObjectResult>(result);
    }
}