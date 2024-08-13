namespace PackIT.Infrastructure.Data.Contexts;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PackIT.Application.Common.DTO;
using PackIT.Application.Common.Interfaces;
using PackIT.Infrastructure.EF.Configurations;
using PackIT.Infrastructure.Identity;

internal sealed class ReadDbContext : IdentityDbContext<ApplicationUser>, IApplicationReadDbContext
{
    public DbSet<PackingListReadModel> PackingLists { get; set; }

    public ReadDbContext(DbContextOptions<ReadDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var configuration = new ReadConfiguration();
        modelBuilder.ApplyConfiguration<PackingItemReadModel>(configuration);
        modelBuilder.ApplyConfiguration<PackingListReadModel>(configuration);

        base.OnModelCreating(modelBuilder);
    }
}
