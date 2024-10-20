using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AmlApi.DataAccess.Entities;

public class NotificationType
{
    [Key] public int Key { get; set; }

    [NotNull] public string Type { get; set; }

    public bool IsEnabled { get; set; }
}