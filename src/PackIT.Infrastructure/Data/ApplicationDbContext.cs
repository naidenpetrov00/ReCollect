namespace PackIT.Infrastructure.Data;

using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PackIT.Application.Common.Interfaces;
using PackIT.Domain.AggregatesModel.PackingAggregate.Entities;
using PackIT.Domain.ValueObjects.PackingItems;
using PackIT.Infrastructure.Identity;

internal sealed class ApplicationDbContext
    : IdentityDbContext<ApplicationUser>,
        IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<PackingList> PackingLists { get; set; }
    public DbSet<PackingItem> PackingItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
