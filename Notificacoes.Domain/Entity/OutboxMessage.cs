using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Notificacoes.Domain.Entity
{
    [Collection("outbox")]

    public class OutboxMessage
    {
        public ObjectId Id { get; set; }
        public DateTime OccurredOn { get; set; }
        public string Type { get; set; } = default!;
        public string Payload { get; set; } = default!;
        public DateTime? ProcessedAt { get; set; }

    }
}
