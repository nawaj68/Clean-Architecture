using System.ComponentModel.DataAnnotations;
using AutoMapper;
using JetBrains.Annotations;
using TaskManagement.Models;
using TaskManagement.Shared;

namespace TaskManagement.Service.Models;

public class VMEmployee : IVM
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

    /// <summary>
    ///     User User Name
    /// </summary>
    [MaxLength(50)]
    public string UserName { get; set; } = string.Empty;


    public int Id { get; set; }


}
[UsedImplicitly]
public class Mapping : Profile
{
	public Mapping()
	{
		CreateMap<VMEmployee, Employee>().ReverseMap();
        CreateMap<VMTourist, Tourist>().ReverseMap();
    }
}