

public record CreateNotificationRequest(
    string Type,
    string Recipient,
    string Title,
    string Body,
    DateTime? ScheduledAt,
    string? TenantId);


public record NotificationResponse(
    string Id,
    string Status,
    DateTime? ScheduledAt,
    DateTime? SentAt,
    int Retries,
    string? LastError);