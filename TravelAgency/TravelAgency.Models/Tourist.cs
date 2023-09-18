using TravelAgency.Shared;
using TravelAgency.Shared.Common;

namespace TravelAgency.Models;

public class Tourist  : BaseAuditableEntity, IEntity
{
    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Email
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Phone
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Age
    /// </summary>
    public string? Age { get; set; }

    /// <summary>
    /// JournyDate
    /// </summary>
    public DateTime JournyDate { get; set; }

}
