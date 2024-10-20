using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AmlApi.DataAccess.Entities;

public class Location
{
    [Key] public int Key { get; set; }

    [NotNull] public string BranchName { get; set; }

    public bool IsEnabled { get; set; }

    public string OpeningTime { get; set; }
    
    public string ClosingTime { get; set; }
}