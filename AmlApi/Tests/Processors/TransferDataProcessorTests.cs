using AmlApi.Business.Processor;
using AmlApi.DataAccess;
using AmlApi.DataAccess.Entities;
using AmlApi.DataAccess.Queries;
using AmlApi.DataAccess.Queries.Commands.Interfaces;
using AmlApi.DataAccess.Queries.Interfaces;
using AmlApi.Resources;
using Moq;

namespace Tests.Processors;

public class TransferDataProcessorTests : DbTestBase<TransferDataProcessor>
{
    [Fact]
    public async void ProcessMediaExistsInTransferToBranch()
    {
        using (var stubContext = this.CreateAppDataContext())
        {
            var stubTransferData = new TransferData()
            {
                Key = 1,
                Branch = 1,
                StockLevel = 10
            };
            
            var stubToBeTransferred = new Inventory()
            {
                Key = 1,
                Name = "name",
                MediaTypeKey = 1,
                BranchKey = 1,
                Author = "John Doe",
                PublicationYear = 2012,
                StockLevel = 20
            };

            this.AutoMocker.GetMock<IDataContextFactory>()
                .Setup(x => x.Create())
                .Returns(stubContext);

            this.AutoMocker.GetMock<IGetByKeyQuery>()
                .Setup(x => x.Get<Inventory>(stubTransferData.Key))
                .ReturnsAsync(stubToBeTransferred);

            this.AutoMocker.GetMock<IGetMediaByNameAndBranchQuery>()
                .Setup(x => x.Execute(stubContext, stubToBeTransferred.Name, stubTransferData.Branch))
                .ReturnsAsync((Inventory)null);
            
            var stubMedia = new Inventory
            {
                Name = stubToBeTransferred.Name,
                MediaTypeKey =stubToBeTransferred.Key,
                BranchKey = stubToBeTransferred.BranchKey,
                StockLevel = stubTransferData.StockLevel,
                Author = stubToBeTransferred.Author,
                PublicationYear = stubToBeTransferred.PublicationYear
            };

            var sut = this.CreateTestSubject();
            var result = await sut.Process(stubTransferData);
            
            Assert.Equal("Transferred Media Successfully", result);
            
             this.AutoMocker.GetMock<IInsertEntityCommand>()
                 .Verify(x => x.Execute(It.IsAny<Inventory>()), Times.Once);
        }
    }
    
    [Fact]
    public async void ProcessMediaDoesNotExistsInTransferToBranch()
    {
        using (var stubContext = this.CreateAppDataContext())
        {
            var stubTransferData = new TransferData()
            {
                Key = 1,
                Branch = 1,
                StockLevel = 10
            };
            
            var stubToBeTransferred = new Inventory()
            {
                Key = 1,
                Name = "name",
                MediaTypeKey = 1,
                BranchKey = 1,
                Author = "John Doe",
                PublicationYear = 2012,
                StockLevel = 20
            };

            var stubTransferringTo = new Inventory()
            {
                Key = 20,
                Name = "name",
                MediaTypeKey = 1,
                BranchKey = 1,
                Author = "John Doe",
                PublicationYear = 2012,
            };

            this.AutoMocker.GetMock<IDataContextFactory>()
                .Setup(x => x.Create())
                .Returns(stubContext);

            this.AutoMocker.GetMock<IGetByKeyQuery>()
                .Setup(x => x.Get<Inventory>(stubTransferData.Key))
                .ReturnsAsync(stubToBeTransferred);

            this.AutoMocker.GetMock<IGetMediaByNameAndBranchQuery>()
                .Setup(x => x.Execute(stubContext, stubToBeTransferred.Name, stubTransferData.Branch))
                .ReturnsAsync(stubTransferringTo);

            stubTransferringTo.StockLevel += stubTransferData.StockLevel;

            var sut = this.CreateTestSubject();
            var result = await sut.Process(stubTransferData);
            
            Assert.Equal("Transferred Media Successfully", result);
            
            this.AutoMocker.GetMock<IInsertEntityCommand>()
                .Verify(x => x.Execute(It.IsAny<Inventory>()), Times.Never);
            
            this.AutoMocker.GetMock<IUpdateEntityCommand>()
                .Verify(x => x.Execute(It.IsAny<Inventory>()), Times.Exactly(2));
        }
    }
}