using AmlApi.Business.Processor;
using AmlApi.Controllers;
using AmlApi.Resources;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Tests.Controllers;

public class InventoryControllerTests : DbTestBase<InventoryController>
{
    [Fact]
    public async void TransferMediaSuccess()
    {
        var stubTransferData = new TransferData();
        var expected = "Success";

        this.AutoMocker.GetMock<ITransferDataProcessor>()
            .Setup(x => x.Process(stubTransferData))
            .ReturnsAsync(expected);

        var sut = this.CreateTestSubject();
        var result = await sut.TransferMedia(stubTransferData) as OkObjectResult;

        Assert.IsType<OkObjectResult>(result);
        Assert.Equal(expected, result.Value);
        
        this.AutoMocker.GetMock<ITransferDataProcessor>()
            .Verify(x => x.Process(stubTransferData), Times.Once);
    }

    [Fact]
    public async void TransferMediaCatchesException()
    {
        var stubTransferData = new TransferData();
        var expected = "oopsie";

        this.AutoMocker.GetMock<ITransferDataProcessor>()
            .Setup(x => x.Process(stubTransferData))
            .ThrowsAsync(new Exception(expected));

        var sut = this.CreateTestSubject();
        var result = await sut.TransferMedia(stubTransferData) as BadRequestObjectResult;

        Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal(expected, result.Value);
    }
}