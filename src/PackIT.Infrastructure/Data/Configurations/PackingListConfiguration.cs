namespace PackIT.Infrastructure.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PackIT.Application.Common.DTO;
using PackIT.Domain.AggregatesModel.PackingAggregate.Entities;

internal sealed class PackingListConfiguration
    : IEntityTypeConfiguration<PackingListReadModel>,
        IEntityTypeConfiguration<PackingList>
{
    public void Configure(EntityTypeBuilder<PackingListReadModel> builder)
    {
        builder.ToTable("PackingLists");
        builder.OwnsOne(b => b.Localization);
    }

    public void Configure(EntityTypeBuilder<PackingList> builder)
    {
        builder.OwnsOne(b => b.Name);
        builder.OwnsOne(b => b.Localization);
    }
}
