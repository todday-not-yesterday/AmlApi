using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace AmlApi.DataAccess.Entities;

[ExcludeFromCodeCoverage]
public class Inventory
{
    [Key] public int Key { get; set; }

    public string Name { get; set; }

    public int MediaTypeKey { get; set; }

    public int BranchKey { get; set; }

    public int StockLevel { get; set; }
    
    public string Author { get; set; }
    
    public int? PublicationYear { get; set; }
    
    [ForeignKey(nameof(MediaTypeKey))] public MediaType MediaType { get; set; }
    
    [ForeignKey(nameof(BranchKey))] public Branch Branch { get; set; }
}