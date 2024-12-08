using AmlApi.Business.Getters;
using AmlApi.DataAccess.Queries.Interfaces;
using Moq;

namespace Tests.Controllers.Getters;

public class UserControllerTests : DbTestBase<GetLogin>
{
    [Fact]
    public async Task GetLogin_ShouldReturnTrue_WhenCredentialsAreValid()
    {
        var stubUsername = "user";
        var stubPassword = "password";

        this.AutoMocker.GetMock<ICheckLoginQuery>()
            .Setup(x => x.Get(stubUsername, stubPassword))
            .ReturnsAsync(1);

        var sut = this.CreateTestSubject();

        var result = await sut.Get(stubUsername, stubPassword);

        Assert.True(result);
    }

    [Fact]
    public async Task GetLogin_ShouldReturnFalse_WhenCredentialsAreInvalid()
    {
        var stubUsername = "user";
        var stubPassword = "wrongpassword";

        this.AutoMocker.GetMock<ICheckLoginQuery>()
            .Setup(x => x.Get(stubUsername, stubPassword))
            .ReturnsAsync(0);

        var sut = this.CreateTestSubject();

        var result = await sut.Get(stubUsername, stubPassword);

        Assert.False(result);
    }
}