using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using AmlApi.DataAccess.Queries.Interfaces;

namespace AmlApi.DataAccess.Entities;

[ExcludeFromCodeCoverage]
public class UserInventory : IHasKey
{
    [Key] public int Key { get; set; }

    public int InventoryKey { get; set; }

    public DateTime BorrowedDate { get; set; }
    
    public DateTime ReturnDate { get; set; }
    
    public int UserKey { get; set; }
    
    public int StatusKey { get; set; }
    
    [ForeignKey(nameof(InventoryKey))] 
    public Inventory Inventory { get; set; }
    
    [ForeignKey(nameof(UserKey))] 
    public User User { get; set; }
    
    [ForeignKey(nameof(StatusKey))] 
    public MediaStatus MediaStatus { get; set; }
}