using System.Globalization;
using CsvHelper;
using TaskManagement.Shared.Common.Interfaces;

namespace TaskManagement.Infrastructure.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile<T>(IEnumerable<T> records) where T : class
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Context.RegisterClassMap(typeof(T));
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}