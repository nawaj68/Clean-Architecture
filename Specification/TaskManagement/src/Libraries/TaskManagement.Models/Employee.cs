using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using TaskManagement.Shared;
using TaskManagement.Shared.Common;

namespace TaskManagement.Models;

[ExcludeFromCodeCoverage]
public class Employee : BaseAuditableEntity, IEntity
{
    /// <summary>
    ///     User Email
    /// </summary>
    [MaxLength(50)]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    ///     First Name
    /// </summary>
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    ///     Last Name
    /// </summary>
    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    ///     User Phone Number
    /// </summary>
    [MaxLength(20)]
    public string Phone { get; set; } = string.Empty;
}