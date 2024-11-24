using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using AmlApi.Business.Creators.Interfaces;
using AmlApi.Business.Processor.Interfaces;
using AmlApi.Business.Updaters;
using AmlApi.Business.Updaters.Interfaces;
using AmlApi.DataAccess;
using AmlApi.DataAccess.Entities;
using AmlApi.DataAccess.Queries.Commands.Interfaces;
using AmlApi.DataAccess.Queries.Interfaces;
using AmlApi.Resources;

namespace AmlApi.Business.Processor;

public class MediaBorrowProcessor : IMediaBorrowProcessor
{
    private readonly IGetByKeyQuery getByKeyQuery;
    private readonly IUserInventoryCreator userInventoryCreator;
    private readonly IStockLevelUpdater stockLevelUpdater;
    private readonly IDataContextFactory dataContextFactory;

    public MediaBorrowProcessor(IGetByKeyQuery getByKeyQuery, 
        IUserInventoryCreator userInventoryCreator, 
        IStockLevelUpdater stockLevelUpdater, IDataContextFactory dataContextFactory)
    {
        this.getByKeyQuery = getByKeyQuery;
        this.userInventoryCreator = userInventoryCreator;
        this.stockLevelUpdater = stockLevelUpdater;
        this.dataContextFactory = dataContextFactory;
    }

    public async Task<BorrowMediaResponse> Borrow(int mediaKey, int userKey)
    {
        var mediaToBorrow = await getByKeyQuery.Get<Inventory>(mediaKey);
        var user = await getByKeyQuery.Get<User>(userKey);

        if (user == null || mediaToBorrow == null)
        {
            return new BorrowMediaResponse
            {
                Success = false
            };
        }

        var mediaType = await getByKeyQuery.Get<MediaType>(mediaToBorrow.MediaTypeKey);
        
        userInventoryCreator.Create(mediaKey, userKey);

        stockLevelUpdater.Update(mediaKey, 1, false);

        return new BorrowMediaResponse
        {
            Success = true,
            Message = $"The {mediaType.Name} {mediaToBorrow.Name} has been successfully borrowed"
        };
    }
}