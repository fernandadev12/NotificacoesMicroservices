using MongoDB.Bson;
using Notificacoes.Domain.Entity;

namespace Notificacoes.Domain.Repository.Interfaces
{
    public interface INotificationRepository
    {
        Task<Notification?> GetByIdAsync(ObjectId id, CancellationToken ct);
        Task AddAsync(Notification entity, CancellationToken ct);
        Task UpdateAsync(Notification entity, CancellationToken ct);
        Task<IReadOnlyList<Notification>> GetPendingAsync(DateTime now, int take, CancellationToken ct);

    }
}
