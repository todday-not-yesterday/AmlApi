using AmlApi.Business.Creators.Interfaces;
using AmlApi.Business.Processor;
using AmlApi.Business.Updaters.Interfaces;
using AmlApi.DataAccess.Entities;
using AmlApi.DataAccess.Queries.Commands.Interfaces;
using AmlApi.DataAccess.Queries.Interfaces;
using AmlApi.Resources;
using Moq;
using Newtonsoft.Json;

namespace Tests.Processors;

public class MediaBorrowProcessorTests : TestBase<MediaBorrowProcessor>
{
     [Fact]
     public async void BorrowReturnsAsExpected()
     {
          var mediaKey = 10;
          var userKey = 19;

          var stubMediaType = new MediaType
          {
               Key = 23,
               Name = "Book",
               IsEnabled = true
          };
          
          var stubMediaToBorrow = new Inventory
          {
               Key = mediaKey,
               MediaTypeKey = 23,
               MediaType = stubMediaType,
               Name = "Smart book"
          };

          var stubUser = new User
          {
               Key = userKey,
               FirstName = "Hamza",
               LastName = "Soussi"
          };

          var expected = new BorrowMediaResponse
          {
               Success = true,
               Message = $"The {stubMediaType.Name} {stubMediaToBorrow.Name} has been successfully borrowed"
          };

          AutoMocker.GetMock<IGetByKeyQuery>()
               .Setup(x => x.Get<Inventory>(mediaKey))
               .ReturnsAsync(stubMediaToBorrow);
          
          AutoMocker.GetMock<IGetByKeyQuery>()
               .Setup(x => x.Get<User>(userKey))
               .ReturnsAsync(stubUser);
          
          AutoMocker.GetMock<IGetByKeyQuery>()
               .Setup(x => x.Get<MediaType>(stubMediaToBorrow.MediaTypeKey))
               .ReturnsAsync(stubMediaType);

          var sut = CreateTestSubject();
          var result = await sut.Borrow(mediaKey, userKey);

          Assert.IsType<BorrowMediaResponse>(result);
          Assert.Equal(JsonConvert.SerializeObject(result), JsonConvert.SerializeObject(expected));

          AutoMocker.GetMock<IUserInventoryCreator>()
               .Verify(x => x.Create(mediaKey, userKey), Times.Once);
          AutoMocker.GetMock<IStockLevelUpdater>()
               .Verify(x => x.Update(mediaKey, 1, false), Times.Once);
          AutoMocker.GetMock<IInsertEntityCommand>()
               .Verify(x => x.Execute(It.IsAny<Notification>()), Times.Once);
     }
}