
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;


namespace Notificacoes.Domain.Entity
{
    [Collection("notifications")]

    public class Notification
    {
        public ObjectId Id { get; set; }
        public string Type { get; set; } = default!;
        public string Recipient { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Body { get; set; } = default!;
        public string Status { get; set; } = "Pending";
        public DateTime? ScheduledAt { get; set; }
        public DateTime? SentAt { get; set; }
        public int Retries { get; set; }
        public string? LastError { get; set; }
        public string? TenantId { get; set; }
    }
}
