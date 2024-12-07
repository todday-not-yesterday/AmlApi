﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using AmlApi.DataAccess.Queries.Interfaces;

namespace AmlApi.DataAccess.Entities;

[ExcludeFromCodeCoverage]
public class NotificationSendType : IHasKey
{
    [Key] public int Key { get; set; }

    [NotNull] public string Type { get; set; }
}