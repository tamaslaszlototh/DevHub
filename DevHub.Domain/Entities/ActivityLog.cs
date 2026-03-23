using DevHub.Domain.Enums;
using DevHub.Domain.ValueObjects;

namespace DevHub.Domain.Entities;

public sealed class ActivityLog
{
    public Guid Id { get; private set; }
    public string UserId { get; private set; }
    public Guid TenantId { get; private set; }
    public ActivityCategory Category { get; private set; }
    public DateRange TimeSlot { get; private set; }
    public string? Description { get; private set; }

    public ActivityLog(string userId, Guid tenantId, ActivityCategory category, DateRange timeSlot, string? description)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        TenantId = tenantId;
        Category = category;
        TimeSlot = timeSlot;
        Description = description;
    }
}