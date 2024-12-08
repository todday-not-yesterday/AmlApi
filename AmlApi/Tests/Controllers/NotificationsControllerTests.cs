using AmlApi.Business.Getters;
using AmlApi.Business.Getters.Interfaces;
using AmlApi.Business.Processor;
using AmlApi.Business.Processor.Interfaces;
using AmlApi.Controllers;
using AmlApi.Resources;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Tests.Controllers;

public class NotificationsControllerTests : TestBase<NotificationsController>
{
    [Fact]
    public async void GetNotificationsSuccess()
    {
        var stubUserKey = 1;

        var stubNotifications = new List<NotificationsResponse>();

        this.AutoMocker.GetMock<INotificationsGetter>()
            .Setup(x => x.Get(stubUserKey))
            .ReturnsAsync(stubNotifications);

        var sut = this.CreateTestSubject();
        var result = await sut.GetNotificationsForUser(stubUserKey) as OkObjectResult;

        Assert.IsType<OkObjectResult>(result);
        Assert.Equal(stubNotifications, result.Value);
    }
    
    [Fact]
    public async void GetNotificationsCatchesException()
    {
        var stubUserKey = 1;
        
        this.AutoMocker.GetMock<INotificationsGetter>()
            .Setup(x => x.Get(stubUserKey))
            .Throws(new Exception("Failed"));

        var sut = this.CreateTestSubject();
        var result = await sut.GetNotificationsForUser(stubUserKey) as BadRequestObjectResult;

        Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Failed", result.Value);
    }

    [Fact]
    public async void PollForNotificationsToSendSuccess()
    {
        var sut = this.CreateTestSubject();
        var result = await sut.PollForNotificationsToSend();

        Assert.IsType<OkResult>(result);
        
        this.AutoMocker.GetMock<INotificationsToSendProcessor>()
            .Verify(x => x.Process(), Times.Once);
    }
    
    [Fact]
    public async void PollForOverdueMediaSuccess()
    {
        var sut = this.CreateTestSubject();
        var result = await sut.PollForOverdueMedia();

        Assert.IsType<OkResult>(result);
        
        this.AutoMocker.GetMock<IOverdueMediaProcessor>()
            .Verify(x => x.Process(), Times.Once);
    }
}