namespace PackIT.Infrastructure.Data.Contexts;

using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PackIT.Application.Common.Interfaces;
using PackIT.Domain.AggregatesModel.PackingAggregate.Entities;
using PackIT.Infrastructure.Identity;

internal sealed class WriteDbContext
    : IdentityDbContext<ApplicationUser>,
        IApplicationWriteDbContext
{
    public DbSet<PackingList> PackingLists { get; set; }

    public WriteDbContext(DbContextOptions<WriteDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
