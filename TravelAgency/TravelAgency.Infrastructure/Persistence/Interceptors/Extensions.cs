using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Infrastructure.Persistence.Interceptors;

public static class Extensions
{
    public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
    entry.References.Any(r =>
        r.TargetEntry is { } entityEntry &&
        entityEntry.Metadata.IsOwned() &&
        entityEntry.State is EntityState.Added or EntityState.Modified);
}
