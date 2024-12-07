using System.Threading.Tasks;
using AmlApi.Business.Processor.Interfaces;
using AmlApi.DataAccess;
using AmlApi.DataAccess.Entities;
using AmlApi.DataAccess.Queries;
using AmlApi.DataAccess.Queries.Commands.Interfaces;
using AmlApi.DataAccess.Queries.Interfaces;
using AmlApi.Resources;

namespace AmlApi.Business.Processor;

public class TransferDataProcessor : ITransferDataProcessor
{
    private readonly IGetByKeyQuery getByKeyQuery;
    private readonly IDataContextFactory dataContextFactory;
    private readonly IGetMediaByNameAndBranchQuery getMediaByNameAndBranchQuery;
    private readonly IUpdateEntityCommand updateEntityCommand;
    private readonly IInsertEntityCommand insertEntityCommand;

    public TransferDataProcessor(
        IGetByKeyQuery getByKeyQuery,
        IDataContextFactory dataContextFactory,
        IGetMediaByNameAndBranchQuery getMediaByNameAndBranchQuery,
        IUpdateEntityCommand updateEntityCommand,
        IInsertEntityCommand insertEntityCommand)
    {
        this.getByKeyQuery = getByKeyQuery;
        this.dataContextFactory = dataContextFactory;
        this.getMediaByNameAndBranchQuery = getMediaByNameAndBranchQuery;
        this.updateEntityCommand = updateEntityCommand;
        this.insertEntityCommand = insertEntityCommand;
    }

    public async Task<string> Process(TransferData transferData)
    {
        using (var context = this.dataContextFactory.Create())
        {
            var toBeTransferred = await this.getByKeyQuery.Get<Inventory>(transferData.Key);

            var transferringTo = await this.getMediaByNameAndBranchQuery.Execute(context, toBeTransferred.Name, transferData.Branch);

            if (transferringTo == null)
            {
                var newMedia = new Inventory
                {
                    Name = toBeTransferred.Name,
                    MediaTypeKey = toBeTransferred.MediaTypeKey,
                    BranchKey = toBeTransferred.BranchKey,
                    StockLevel = transferData.StockLevel,
                    Author = toBeTransferred.Author,
                    PublicationYear = toBeTransferred.PublicationYear,
                };
                    
                await this.insertEntityCommand.Execute(newMedia);
            }
            else
            {
                transferringTo.StockLevel += transferData.StockLevel;
                await this.updateEntityCommand.Execute(transferringTo);
            }
            
            toBeTransferred.StockLevel -= transferData.StockLevel;
            await this.updateEntityCommand.Execute(toBeTransferred);
        }

        return "Transferred Media Successfully";
    }
}