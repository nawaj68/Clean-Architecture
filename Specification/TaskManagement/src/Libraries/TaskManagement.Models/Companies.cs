using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using TaskManagement.Shared;
using TaskManagement.Shared.Common;

namespace TaskManagement.Models
{
    [ExcludeFromCodeCoverage]
    public class Companies : BaseAuditableEntity, IEntity
    {
        /// <summary>
        /// Name of the company.
        /// </summary>
        [MaxLength(50)]
        public string CompanyName { get; set; } = string.Empty;

        /// <summary>
        /// Address of the company.
        /// </summary>
        [MaxLength(100)]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Owner of the company.
        /// </summary>
        [MaxLength(50)]
        public string Owner { get; set; } = string.Empty;
    }
}
