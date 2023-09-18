using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Shared.Common.Models;

public class PaginatedList<T>
{
    public IReadOnlyCollection<T> Items { get; set; }
    public int PageNumber { get; }
    public int TotalPages { get; }
    public int TotalCount { get; }

    public PaginatedList(IReadOnlyCollection<T> items, int count, int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        TotalCount = count;
        Items = items;
    }

    public bool HasPreviousPage => PageNumber > 1;

    public bool HasNextPage => PageNumber < TotalPages;

    public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
    {
        var count = await source.CountAsync();
        var items =  source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

        return new PaginatedList<T>(items, count, pageNumber, pageSize);
    }

    public static PaginatedList<T> Create(List<T> source, int? pageNumber, int? pageSize)
    {
        var count = source.Count;
        return new PaginatedList<T>(source, count, pageNumber??1, pageSize??10);
    }
}