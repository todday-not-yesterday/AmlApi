using System.Diagnostics.CodeAnalysis;

namespace AmlApi.Resources;

[ExcludeFromCodeCoverage]
public class MediaResource
{
    public int Key { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public int? PublicationYear { get; set; }
    public string MediaType { get; set; }
    public bool Available { get; set; }
    public string BranchName { get; set; }
}