using AmlApi.Business.Getters.Interfaces;
using AmlApi.Controllers;
using AmlApi.Resources;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Tests.Controllers;

public class SearchControllerTests : TestBase<SearchController>
{
    [Fact]
    public async void GetMediaReturnsAsExpected()
    {
        var filters = new Filters
        {
            MediaTypes = new List<int>
            {
                1
            },
            PageNumber = 1,
            PageSize = 1
        };

        var mediaResponse = new GetMediaResponse
        {
            MediaResources = new List<MediaResource>
            {
                new MediaResource
                {
                    Name = "Coding standards",
                    MediaType = "Book",
                    Available = true,
                    Author = "Hamza"
                }
            },
            MediaCount = 1
        };
        
        AutoMocker.GetMock<IGetMappedMediaByFilters>()
            .Setup(x => x.Get(filters))
            .ReturnsAsync(mediaResponse);

        var sut = CreateTestSubject();
        var result = await sut.GetMedia(filters) as OkObjectResult;
        
        Assert.IsType<OkObjectResult>(result);
        Assert.Equal(mediaResponse, result.Value);
        
        AutoMocker.GetMock<IGetMappedMediaByFilters>()
            .Verify(x => x.Get(filters), Times.Once);
    }
    
    [Fact]
    public async void GetMediaReturnsThrowsAnException()
    {
        var filters = new Filters
        {
            MediaTypes = new List<int>
            {
                1
            },
            PageNumber = 1,
            PageSize = 1
        };

        AutoMocker.GetMock<IGetMappedMediaByFilters>()
            .Setup(x => x.Get(filters))
            .ThrowsAsync(new Exception());

        var sut = CreateTestSubject();
        var result = await sut.GetMedia(filters);
        
        Assert.IsType<BadRequestObjectResult>(result);
        
        AutoMocker.GetMock<IGetMappedMediaByFilters>()
            .Verify(x => x.Get(filters), Times.Once);
    }
}