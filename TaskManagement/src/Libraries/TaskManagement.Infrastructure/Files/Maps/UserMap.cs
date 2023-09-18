using CsvHelper.Configuration;
using System.Globalization;
using TaskManagement.Service.Models;

namespace TaskManagement.Infrastructure.Files.Maps;

public sealed class UserMap : ClassMap<VMEmployee>
{
    public UserMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        //Map(m => m.).Convert(c => c.Value.Done ? "Yes" : "No");
    }
}