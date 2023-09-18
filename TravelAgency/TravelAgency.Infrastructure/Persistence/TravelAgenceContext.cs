using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Infrastructure.Common;
using TravelAgency.Infrastructure.Persistence.Interceptors;
using TravelAgency.Models;
using TravelAgency.Shared.Common.Interface;

namespace TravelAgency.Infrastructure.Persistence;

public class TravelAgenceContext  : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    //private readonly AuditableEntitySaveChangesInterceptor? _auditableEntitySaveChangesInterceptor;
    private readonly IMediator? _mediator;

    public TravelAgenceContext(DbContextOptions<TravelAgenceContext> options, IMediator? mediator = null
    /*AuditableEntitySaveChangesInterceptor? auditableEntitySaveChangesInterceptor = null*/) : base(options)
    {
        _mediator = mediator;
        //_auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        if (_mediator is not null)
            await _mediator.DispatchDomainEvents(this);

        return await base.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc />
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    if (_auditableEntitySaveChangesInterceptor is not null)
    //        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    //}

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TravelAgenceContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }


}
