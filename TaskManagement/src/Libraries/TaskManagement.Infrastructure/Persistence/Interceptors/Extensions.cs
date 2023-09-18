using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Infrastructure.Persistence.Interceptors;

public static class Extensions
{
    public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
        entry.References.Any(r => 
            r.TargetEntry is { } entityEntry && 
            entityEntry.Metadata.IsOwned() && 
            entityEntry.State is EntityState.Added or EntityState.Modified);
}