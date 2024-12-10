namespace ReCollect.Infrastructure.Data;

using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReCollect.Application.SeedWork.Interfaces;
using ReCollect.Domain.AggregatesModel.PackingAggregate.Entities;
using ReCollect.Infrastructure.Identity;
using ReCollect.Infrastructure.SeedWork;

public sealed class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    private readonly IMediator mediatR;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IMediator mediatR)
        : base(options)
    {
        this.mediatR = mediatR;
    }

    public DbSet<PackingList> PackingLists => Set<PackingList>();
    public DbSet<PackingItem> PackingItems => Set<PackingItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await this.mediatR.DispatchDomainEventsAsync(this);

        return await base.SaveChangesAsync(cancellationToken);
    }
}
