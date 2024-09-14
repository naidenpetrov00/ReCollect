namespace ReCollect.Infrastructure.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReCollect.Domain.AggregatesModel.PackingAggregate.Entities;

internal sealed class PackingListConfiguration : IEntityTypeConfiguration<PackingList>
{
    public void Configure(EntityTypeBuilder<PackingList> builder)
    {
        builder.OwnsOne(b => b.Name);
        builder.OwnsOne(b => b.Localization);
    }
}
