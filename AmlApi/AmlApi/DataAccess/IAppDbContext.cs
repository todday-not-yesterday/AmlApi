using System;
using System.Threading;
using System.Threading.Tasks;
using AmlApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AmlApi.DataAccess;

public interface IAppDbContext : IDisposable
{
    DbSet<Inventory> Inventories { get; set; }
    DbSet<Location> Locations { get; set; }
    DbSet<MediaType> MediaTypes { get; set; }
    DbSet<Notification> Notifications { get; set; }
    DbSet<NotificationStatus> NotificationStatuses { get; set; }
    DbSet<NotificationType> NotificationTypes { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<UserInventory> UserInventories { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
}