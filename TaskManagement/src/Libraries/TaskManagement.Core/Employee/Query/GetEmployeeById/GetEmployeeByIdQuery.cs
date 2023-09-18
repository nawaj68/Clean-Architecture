using System.Text.Json.Serialization;

using TaskManagement.Service.Models;

namespace TaskManagement.Core.Employee.Query.GetEmployeeById;

public class GetEmployeeByIdQuery : IRequest<VMEmployee>
{
	[JsonConstructor]
	public GetEmployeeByIdQuery(int id)
	{
		Id = id;
	}

	public int Id { get; set; }

}