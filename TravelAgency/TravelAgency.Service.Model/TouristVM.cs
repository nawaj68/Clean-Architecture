using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Shared;

namespace TravelAgency.Service.Model;

public class TouristVM :IVM
{
    /// <summary>
    /// Tourist Name
    /// </summary>
    [MaxLength(30)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Tourist Email
    /// </summary>
    [MaxLength(20)]
    public string? Email { get; set; }

    /// <summary>
    /// Tourist PhoneNumber
    /// </summary>
    [MaxLength(11)]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Tourist Age
    /// </summary>
    [MaxLength(3)]
    public string? Age { get; set; }

    /// <summary>
    /// Tourist Journy Date
    /// </summary>
    public DateTime JournyDate { get; set; }

    public int Id { get; set; }

}
