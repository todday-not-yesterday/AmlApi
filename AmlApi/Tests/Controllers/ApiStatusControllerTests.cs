using AmlApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Tests.Controllers;

public class ApiStatusControllerTests : DbTestBase<ApiStatusController>
{
    [Fact]
    public void ApiStatusSuccess()
    {
        var sut = this.CreateTestSubject();
        var result = sut.Status();
        
        Assert.IsType<OkObjectResult>(result);
    }
}