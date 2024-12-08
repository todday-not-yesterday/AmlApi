using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AmlApi.Resources;

[ExcludeFromCodeCoverage]
public class NotificationsResponse
{
    public int Key { get; set; }
    public int UserKey { get; set; }
    public string NotificationType { get; set; }
    public string NotificationStatus { get; set; }
    public DateTime AddedDate { get; set; }
    public DateTime SendAt { get; set; }
    public string NotificationSendType { get; set; }
}