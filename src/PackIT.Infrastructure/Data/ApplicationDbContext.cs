namespace PackIT.Infrastructure.Data;

using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PackIT.Application.Common.Interfaces;
using PackIT.Domain.AggregatesModel.PackingAggregate.Entities;
using PackIT.Domain.ValueObjects.PackingItems;
using PackIT.Infrastructure.Identity;
using PackIT.Infrastructure.SeedWork;

public sealed class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    private readonly IMediator mediatR;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IMediator mediatR)
        : base(options)
    {
        this.mediatR = mediatR;
    }

    public DbSet<PackingList> PackingLists { get; set; }
    public DbSet<PackingItem> PackingItems { get; set; }

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
