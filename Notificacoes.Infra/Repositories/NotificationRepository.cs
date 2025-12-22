using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using Notificacoes.Domain.Entity;
using Notificacoes.Domain.Repository.Interfaces;
using Notificacoes.Infra.Persistence;

public class NotificationRepository : INotificationRepository
{
    private readonly NotificationsDbContext _db;
    public NotificationRepository(NotificationsDbContext db) => _db = db;

    public Task<Notification?> GetByIdAsync(ObjectId id, CancellationToken ct) =>
        _db.Notifications.FirstOrDefaultAsync(n => n.Id == id, ct);

    public async Task AddAsync(Notification entity, CancellationToken ct)
    {
        await _db.Notifications.AddAsync(entity, ct);
        await _db.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Notification entity, CancellationToken ct)
    {
        _db.Notifications.Update(entity);
        await _db.SaveChangesAsync(ct);
    }

    public Task<IReadOnlyList<Notification>> GetPendingAsync(DateTime now, int take, CancellationToken ct) =>
        _db.Notifications
            .Where(n => n.Status == "Pending" &&
                        (n.ScheduledAt == null || n.ScheduledAt <= now))
            .OrderBy(n => n.ScheduledAt)
            .Take(take)
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<Notification>)t.Result!, ct);
}