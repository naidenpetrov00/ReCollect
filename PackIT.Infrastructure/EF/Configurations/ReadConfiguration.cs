namespace PackIT.Infrastructure.EF.Config
{
	using PackIT.Infrastructure.EF.Models;

	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	internal sealed class ReadConfiguration : IEntityTypeConfiguration<PackingListReadModel>
	{
		public void Configure(EntityTypeBuilder<PackingListReadModel> builder)
		{
			builder.HasKey(x => x.Id);
			builder
				.Property(pl => pl.Localization)
				.HasConversion(pl => pl.ToString(), pl => LocalizationReadModel.Create(pl));
			builder
				.HasMany(pl => pl.Items)
				.WithOne(pi => pi.PackingList);
		}
	}
}
