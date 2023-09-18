﻿#nullable enable
using TaskManagement.Shared.Enums;

namespace TaskManagement.Shared.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;

    public string CreatedBy { get; set; } = string.Empty;

    public DateTimeOffset? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public EntityStatus Status { get; set; }
}