using AmlApi.Business.Getters;
using AmlApi.DataAccess.Queries.Interfaces;
using Moq;

namespace Tests.Getters;

public class UserControllerTests : DbTestBase<GetLogin>
{
    [Fact]
    public async Task GetLogin_ShouldReturnTrue_WhenCredentialsAreValid()
    {
        var stubUsername = "user";
        var stubPassword = "password";
        var userKey = 23;

        AutoMocker.GetMock<ICheckLoginQuery>()
            .Setup(x => x.Get(stubUsername, stubPassword))
            .ReturnsAsync(userKey);

        var sut = this.CreateTestSubject();

        var result = await sut.Get(stubUsername, stubPassword);

        Assert.Equal(userKey, result);
    }
}