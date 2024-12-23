﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using AmlApi.DataAccess.Queries.Interfaces;

namespace AmlApi.DataAccess.Entities;

[ExcludeFromCodeCoverage]
public class Branch : IHasKey
{
    [Key] public int Key { get; set; }

    [NotNull] public string Name { get; set; }

    public bool IsEnabled { get; set; }
    
    public string OpeningTime { get; set; }
    
    public string ClosingTime { get; set; }
    
    public int LocationKey { get; set; }

    [ForeignKey(nameof(LocationKey))] public Location Location { get; set; }
}