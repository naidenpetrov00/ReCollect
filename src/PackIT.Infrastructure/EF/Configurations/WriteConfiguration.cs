namespace PackIT.Infrastructure.EF.Configurations
{
	using PackIT.Domain.Entities;

	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
	using PackIT.Domain.ValueObjects.PackingItems;
	using PackIT.Domain.ValueObjects.PackingLists;

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
				.Property(typeof(Localization), "Localization")
				.HasConversion(localizationConverter)
				.HasColumnName("Localization");
			builder
				.Property(typeof(PackingListName), "Name")
				.HasConversion(packingListNameConverter)
				.HasColumnName("Name");

			builder
				.HasMany(typeof(PackingItem), "Items");
			builder.ToTable("PackingLists");
		}

		public void Configure(EntityTypeBuilder<PackingItem> builder)
		{
			builder.Property<Guid>("Id");
			builder
				.Property(pi => pi.Name)
				.HasConversion(new ValueConverter<PackingItemName, string>(n => n.Value, n => new PackingItemName(n)));
			builder.Property(pi => pi.Quantity);
			builder.Property(pi => pi.IsPacked);

			builder.ToTable("PackingItems");
		}
	}
}
