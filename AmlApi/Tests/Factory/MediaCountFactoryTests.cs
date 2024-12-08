using AmlApi.Business.Factory;
using AmlApi.DataAccess.Enums;
using AmlApi.DataAccess.Queries.Interfaces;
using Moq;

namespace Tests.Factory;

public class MediaCountFactoryTests : TestBase<MediaCountFactory>
{
    [Theory]
    [InlineData(MediaEnquiryTypeEnum.Borrow)]
    [InlineData(MediaEnquiryTypeEnum.Return)]
    [InlineData(MediaEnquiryTypeEnum.ManageInventory)]
    public async void GetCounterReturnsAsExpected(MediaEnquiryTypeEnum mediaEnquiryTypeEnum)
    {
        var filteredMediaFactoryMock = new Mock<IGetMediaCount>();
        filteredMediaFactoryMock
            .Setup(x => x.MediaEnquiryType)
            .Returns(mediaEnquiryTypeEnum);

        var filters = new List<IGetMediaCount>
        {
            filteredMediaFactoryMock.Object
        };
        
        AutoMocker.Use((IList<IGetMediaCount>) filters);
        
        var sut = CreateTestSubject();
        var result = await sut.GetCounter(mediaEnquiryTypeEnum);

        Assert.NotNull(result);
        Assert.Equal(result.MediaEnquiryType, mediaEnquiryTypeEnum);
    }
}