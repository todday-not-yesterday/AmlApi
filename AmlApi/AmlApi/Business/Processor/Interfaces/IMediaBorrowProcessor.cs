using System.Threading.Tasks;
using AmlApi.Resources;

namespace AmlApi.Business.Processor.Interfaces;

public interface IMediaBorrowProcessor
{
    Task<BorrowMediaResponse> Borrow(int mediaKey, int userKey);
}