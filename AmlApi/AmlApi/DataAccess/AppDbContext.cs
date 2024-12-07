using AmlApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AmlApi.DataAccess;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions contextOptions) : base(contextOptions) { }

    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<MediaType> MediaTypes { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<NotificationSendType> NotificationSendType { get; set; }
    public DbSet<NotificationStatus> NotificationStatuses { get; set; }
    public DbSet<NotificationType> NotificationTypes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserInventory> UserInventories { get; set; }
    public DbSet<Branch> Branches { get; set; }
}