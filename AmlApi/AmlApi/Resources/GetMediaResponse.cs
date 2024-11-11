using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace AmlApi.Resources;

[ExcludeFromCodeCoverage]
public class GetMediaResponse
{
    public List<MediaResource> MediaResources { get; set; }
    public int MediaCount { get; set; }
}