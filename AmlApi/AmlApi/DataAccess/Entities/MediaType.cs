using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using AmlApi.DataAccess.Queries.Interfaces;

namespace AmlApi.DataAccess.Entities;

[ExcludeFromCodeCoverage]
public class MediaType : IHasKey
{
    [Key] public int Key { get; set; }
    
    public string Name { get; set; }
    
    public bool IsEnabled { get; set; }
}