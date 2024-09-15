namespace ReCollect.Infrastructure.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReCollect.Application.Common.DTO;
using ReCollect.Domain.AggregatesModel.PackingAggregate.Entities;
using ReCollect.Domain.ValueObjects.PackingLists;

internal sealed class WriteConfiguration : IEntityTypeConfiguration<PackingItem>
{
    public void Configure(EntityTypeBuilder<PackingItem> builder)
    {
        builder.OwnsOne(b => b.Name);
    }
}
