using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Shared;
using TaskManagement.Shared.Common;

namespace TaskManagement.Models
{
    public class Tourist : BaseAuditableEntity, IEntity
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
}
