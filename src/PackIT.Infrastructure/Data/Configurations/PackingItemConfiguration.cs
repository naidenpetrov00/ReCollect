namespace PackIT.Infrastructure.EF.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PackIT.Application.Common.DTO;
using PackIT.Domain.AggregatesModel.PackingAggregate.Entities;
using PackIT.Domain.ValueObjects.PackingItems;
using PackIT.Domain.ValueObjects.PackingLists;

internal sealed class WriteConfiguration : IEntityTypeConfiguration<PackingItem>
{
    public void Configure(EntityTypeBuilder<PackingItem> builder)
    {
        builder.OwnsOne(b => b.Name);
    }
}
