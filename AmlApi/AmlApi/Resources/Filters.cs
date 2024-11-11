using System.Diagnostics.CodeAnalysis;

namespace AmlApi.Resources;

[ExcludeFromCodeCoverage]
public class Filters
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}