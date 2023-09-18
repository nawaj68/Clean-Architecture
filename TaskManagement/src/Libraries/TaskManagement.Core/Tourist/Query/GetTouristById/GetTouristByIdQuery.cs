using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TaskManagement.Service.Models;

namespace TaskManagement.Core.Tourist.Query.GetTouristById;

public class GetTouristByIdQuery : IRequest<VMTourist>
{
    [JsonConstructor]
    public GetTouristByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
