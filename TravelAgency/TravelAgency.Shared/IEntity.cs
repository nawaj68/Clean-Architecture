using TravelAgency.Shared.Enums;

namespace TravelAgency.Shared;
public interface IEntity<T>
    where T : IEquatable<T>
{
    DateTimeOffset Created { get; set; }
    string CreatedBy { get; set; }

    /// <summary>
    ///     Entity Id.
    /// </summary>
    T Id { get; set; }

    DateTimeOffset? LastModified { get; set; }
    string? LastModifiedBy { get; set; }
    EntityStatus Status { get; set; }
}

public interface IEntity : IEntity<int>
{
}