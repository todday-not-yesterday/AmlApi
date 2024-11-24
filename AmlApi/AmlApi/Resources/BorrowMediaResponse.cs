using System.Diagnostics.CodeAnalysis;

namespace AmlApi.Resources;

[ExcludeFromCodeCoverage]
public class BorrowMediaResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
}