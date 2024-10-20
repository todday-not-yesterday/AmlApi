using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace AmlApi.DataAccess.Entities;

public class Inventory
{
    [Key] public int Key { get; set; }

    public string Name { get; set; }

    public int MediaTypeKey { get; set; }

    public int LocationKey { get; set; }

    public int StockLevel { get; set; }
    
    [ForeignKey(nameof(MediaTypeKey))] public MediaType MediaType { get; set; }
    
    [ForeignKey(nameof(LocationKey))] public Location Location { get; set; }
}