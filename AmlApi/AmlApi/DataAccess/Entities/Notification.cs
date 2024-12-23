﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using AmlApi.DataAccess.Queries.Interfaces;

namespace AmlApi.DataAccess.Entities;

[ExcludeFromCodeCoverage]
public class Notification : IHasKey
{
    [Key] public int Key { get; set; }

    public int UserKey { get; set; }

    public int NotificationTypeKey { get; set; }

    public int NotificationStatusKey { get; set; }

    public DateTime AddedDate { get; set; }
    
    public DateTime SendAt { get; set; }
    
    public int SendTypeKey { get; set; }

    [ForeignKey(nameof(UserKey))] public User User { get; set; }

    [ForeignKey(nameof(NotificationTypeKey))] public NotificationType NotificationType { get; set; }
    
    [ForeignKey(nameof(NotificationStatusKey))] public NotificationStatus NotificationStatus { get; set; }
    
    [ForeignKey(nameof(SendTypeKey))] public NotificationSendType NotificationSendType { get; set; }

}