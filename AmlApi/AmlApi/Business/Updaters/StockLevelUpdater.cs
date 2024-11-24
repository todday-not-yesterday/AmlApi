using AmlApi.Business.Updaters.Interfaces;
using AmlApi.DataAccess;
using AmlApi.DataAccess.Entities;
using AmlApi.DataAccess.Queries.Commands.Interfaces;
using AmlApi.DataAccess.Queries.Interfaces;

namespace AmlApi.Business.Updaters;

public class StockLevelUpdater : IStockLevelUpdater
{
    private readonly IGetByKeyQuery getByKeyQuery;
    private readonly IUpdateEntityCommand updateEntityCommand;

    public StockLevelUpdater(IGetByKeyQuery getByKeyQuery, IUpdateEntityCommand updateEntityCommand)
    {
        this.getByKeyQuery = getByKeyQuery;
        this.updateEntityCommand = updateEntityCommand;
    }

    public async void Update(int mediaKey, int stockNumber, bool isIncrementing)
    {
        var media = await getByKeyQuery.Get<Inventory>(mediaKey);

        var currentStockLevel = media.StockLevel;

        media.StockLevel = isIncrementing ? currentStockLevel += stockNumber : currentStockLevel -= stockNumber;

        await updateEntityCommand.Execute(media);
    }
}