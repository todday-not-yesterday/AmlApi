using System.ComponentModel.DataAnnotations;

namespace AmlApi.DataAccess.Entities;

public class MediaType
{
    [Key] public int Key { get; set; }
    
    public string Name { get; set; }
    
    public bool IsEnabled { get; set; }
}