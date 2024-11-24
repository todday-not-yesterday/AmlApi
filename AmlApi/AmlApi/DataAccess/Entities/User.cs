using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using AmlApi.DataAccess.Queries.Interfaces;

namespace AmlApi.DataAccess.Entities;

[ExcludeFromCodeCoverage]
public class User : IHasKey
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