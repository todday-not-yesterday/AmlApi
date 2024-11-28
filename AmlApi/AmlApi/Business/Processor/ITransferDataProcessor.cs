using System.Threading.Tasks;
using AmlApi.Resources;

namespace AmlApi.Business.Processor;

public interface ITransferDataProcessor
{
    Task<string> Process(TransferData transferData);
}