namespace ReCollect.Infrastructure.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReCollect.Domain.AggregatesModel.PackingAggregate.Entities;

internal sealed class WriteConfiguration : IEntityTypeConfiguration<PackingItem>
{
    public void Configure(EntityTypeBuilder<PackingItem> builder)
    {
        builder.OwnsOne(b => b.Name);
    }
}
