using System.Threading.Tasks;

namespace AmlApi.Business.Processor.Interfaces;

public interface IOverdueMediaProcessor
{
    Task Process();
}