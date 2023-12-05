namespace PackIT.Infrastructure.EF.Configurations
{
	using PackIT.Domain.Entities;
	using PackIT.Domain.ValueObjects;

	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

	internal sealed class WriteConfiguration : IEntityTypeConfiguration<PackingList>, IEntityTypeConfiguration<PackingItem>
	{
		public void Configure(EntityTypeBuilder<PackingList> builder)
		{
			builder.HasKey(pl => pl.Id);

			var localizationConverter = new ValueConverter<Localization, string>(l => l.ToString(), l => Localization.Create(l));
			var packingListNameConverter = new ValueConverter<PackingListName, string>(n => n.Value, n => new PackingListName(n));
			builder
				.Property(pl => pl.Id)
				.HasConversion(id => id.Value, id => new PackingListId(id));

			builder
				.Property(typeof(Localization), "localization")
				.HasConversion(localizationConverter)
				.HasColumnName("Localization");
			builder
				.Property(typeof(PackingListName), "name")
				.HasConversion(packingListNameConverter)
				.HasColumnName("Name");

			builder
				.HasMany(typeof(PackingItem), "items");
		}

		public void Configure(EntityTypeBuilder<PackingItem> builder)
		{
			builder.Property<Guid>("Id");
			builder.Property(pi => pi.Name);
			builder.Property(pi => pi.Quantity);
			builder.Property(pi => pi.IsPacked);
		}
	}
}
