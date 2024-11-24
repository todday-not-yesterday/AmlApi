using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using AmlApi.DataAccess.Queries.Interfaces;

namespace AmlApi.DataAccess.Entities;

[ExcludeFromCodeCoverage]
public class Location : IHasKey
{
    [Key] public int Key { get; set; }
    
    public string PostCode { get; set; }
    
    public int BuildingNumber { get; set; }
    
    public string AddressLineOne { get; set; }
    
    public string AddressLineTwo { get; set; }
    
    public string City { get; set; }
    
    public string County { get; set; }
    
    public string Country { get; set; }
}