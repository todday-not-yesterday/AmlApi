using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using AmlApi.DataAccess.Enums;

namespace AmlApi.Resources;

[ExcludeFromCodeCoverage]
public class Filters
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int? UserKey { get; set; }
    public int? MinimumPublicationYear { get; set; }
    public int? MaximumPublicationYear { get; set; }
    public List<int> MediaTypes { get; set; }
    public List<string> BranchNames { get; set; }
    public MediaEnquiryTypeEnum MediaEnquiryType { get; set; }
}