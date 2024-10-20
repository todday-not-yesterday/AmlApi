using System;
using System.ComponentModel.DataAnnotations;

namespace AmlApi.DataAccess.Entities;

public class User
{
    [Key] 
    public int Key { get; set; }

    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Address { get; set; }
    
    public string PostCode { get; set; }
    
    public string Email { get; set; }
    
    public DateTime DateOfBirth { get; set; }
    
    public string ContactNumber { get; set; }
    
    public string UserName { get; set; }
    
    public string Password { get; set; }
    
    public bool Consent { get; set; }
    
    public bool IsVerified { get; set; }
    
    public int UserLevel { get; set; }
}