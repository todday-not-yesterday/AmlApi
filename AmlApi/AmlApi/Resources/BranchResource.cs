using System.Diagnostics.CodeAnalysis;

namespace AmlApi.Resources;

[ExcludeFromCodeCoverage]
public class BranchResource
{
    public int Key { get; set; }
    public string Name { get; set; }
}