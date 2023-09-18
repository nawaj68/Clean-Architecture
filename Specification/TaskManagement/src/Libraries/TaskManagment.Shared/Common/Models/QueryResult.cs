namespace TaskManagement.Shared.Common.Models;

public class QueryResult<T>
{
    public QueryResult() { }
    public QueryResult(T? result, QueryResultTypeEnum type=QueryResultTypeEnum.Success)
    {
        Result = result;
        Type = type;
    }
    public T? Result { get; set; }
    public QueryResultTypeEnum Type { get; set; }


}