namespace TaskManagement.Shared.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile<T>(IEnumerable<T> records) where T:class;
}