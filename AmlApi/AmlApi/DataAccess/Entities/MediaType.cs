using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AmlApi.DataAccess.Entities;

[ExcludeFromCodeCoverage]
public class MediaType
{
    [Key] public int Key { get; set; }
    
    public string Name { get; set; }
    
    public bool IsEnabled { get; set; }
}