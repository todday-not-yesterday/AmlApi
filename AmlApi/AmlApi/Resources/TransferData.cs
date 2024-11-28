using System.Diagnostics.CodeAnalysis;

namespace AmlApi.Resources;

[ExcludeFromCodeCoverage]
public class TransferData
{
    public int Key { get; set; }
    public int Branch { get; set; }
    public int StockLevel { get; set; }
}