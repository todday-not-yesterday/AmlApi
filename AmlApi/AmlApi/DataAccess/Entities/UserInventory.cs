using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmlApi.DataAccess.Entities;

public class UserInventory
{
    [Key] public int Key { get; set; }

    public int InventoryKey { get; set; }

    public DateTime BorrowedDate { get; set; }
    
    public DateTime ReturnDate { get; set; }
    
    public int UserKey { get; set; }
    
    public bool Returned { get; set; }
    
    [ForeignKey(nameof(InventoryKey))] 
    public Inventory Inventory { get; set; }
    
    [ForeignKey(nameof(UserKey))] 
    public User User { get; set; }
}