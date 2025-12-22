
using Microsoft.EntityFrameworkCore;
using Notificacoes.Domain.Entity;

namespace Notificacoes.Infra.Persistence;

public class NotificationsDbContext : DbContext
{
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<OutboxMessage> OutboxMessages => Set<OutboxMessage>();

    public NotificationsDbContext(DbContextOptions<NotificationsDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Notification>().HasKey(x => x.Id);
        modelBuilder.Entity<OutboxMessage>().HasKey(x => x.Id);

        modelBuilder.Entity<Notification>()
            .HasIndex(x => new { x.Status, x.ScheduledAt });

        modelBuilder.Entity<Notification>()
            .HasIndex(x => x.TenantId);
    }
}