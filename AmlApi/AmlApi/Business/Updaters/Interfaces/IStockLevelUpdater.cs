using AmlApi.DataAccess;

namespace AmlApi.Business.Updaters.Interfaces;

public interface IStockLevelUpdater
{
    void Update(int mediaKey, int stockNumber, bool isIncrementing);
}