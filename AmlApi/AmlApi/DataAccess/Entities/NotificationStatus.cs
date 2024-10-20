using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AmlApi.DataAccess.Entities;

public class NotificationStatus
{
    [Key] public int Key { get; set; }

    [NotNull] public string Status { get; set; }
}