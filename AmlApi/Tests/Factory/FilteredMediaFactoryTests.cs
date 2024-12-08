using System.Collections;
using AmlApi.Business.Factory;
using AmlApi.DataAccess.Enums;
using AmlApi.DataAccess.Queries.Interfaces;
using Moq;

namespace Tests.Factory;

public class FilteredMediaFactoryTests : TestBase<FilteredMediaFactory>
{
    [Theory]
    [InlineData(MediaEnquiryTypeEnum.Borrow)]
    [InlineData(MediaEnquiryTypeEnum.Return)]
    [InlineData(MediaEnquiryTypeEnum.ManageInventory)]
    public async void GetFilterReturnsCorrectImplementation(MediaEnquiryTypeEnum mediaEnquiryTypeEnum)
    {
        var filteredMediaFactoryMock = new Mock<IGetFilteredMedia>();
        filteredMediaFactoryMock
            .Setup(x => x.MediaEnquiryType)
            .Returns(mediaEnquiryTypeEnum);

        var filters = new List<IGetFilteredMedia>
        {
            filteredMediaFactoryMock.Object
        };
        
        AutoMocker.Use((IList<IGetFilteredMedia>) filters);
        
        var sut = CreateTestSubject();
        var result = await sut.GetFilter(mediaEnquiryTypeEnum);

        Assert.NotNull(result);
        Assert.Equal(result.MediaEnquiryType, mediaEnquiryTypeEnum);
    }
}