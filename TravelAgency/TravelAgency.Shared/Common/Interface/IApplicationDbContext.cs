namespace TravelAgency.Shared.Common.Interface;

public interface IApplicationDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
