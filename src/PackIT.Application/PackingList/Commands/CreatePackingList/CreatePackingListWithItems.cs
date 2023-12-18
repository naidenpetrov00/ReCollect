namespace PackIT.Application.PackingList.Commands.CreatePackingList
{
	using PackIT.Application.Services;
	using PackIT.Application.Exceptions;

	using PackIT.Domain.Enums;
	using PackIT.Domain.Factory;
	using PackIT.Domain.Repositories;
	using PackIT.Domain.ValueObjects;

	using System.Threading;
	using System.Threading.Tasks;
	using MediatR;

	public record CreatePackingListWithItems(
		Guid Id,
		string Name,
		ushort Days,
		Gender Gender,
		LocalizationWriteModel Localization) : IRequest;

	public record LocalizationWriteModel(string City, string Country);

	public class CreatePackingListWithItemsHandler : IRequestHandler<CreatePackingListWithItems>
	{
		private readonly IPackingListRepository respository;
		private readonly IPackingListFactory packingListFactory;
		private readonly IPackingListReadService packingListReadService;
		private readonly IWeatherService weatherService;

		public CreatePackingListWithItemsHandler(
			IPackingListRepository respository,
			IPackingListFactory packingListFactory,
			IPackingListReadService packingListReadService,
			IWeatherService weatherService)
		{
			this.respository = respository;
			this.packingListFactory = packingListFactory;
			this.packingListReadService = packingListReadService;
			this.weatherService = weatherService;
		}

		public async Task Handle(CreatePackingListWithItems request, CancellationToken cancellationToken)
		{
			var (id, name, days, gender, localizationWriteModel) = request;

			if (await this.packingListReadService.ExistsByNameAsync(request.Name))
			{
				throw new PackingListAlreadyExistsException(request.Name);
			}

			var localization = new Localization(request.Localization.City, request.Localization.Country);
			var weather = await this.weatherService.GetWeatherAsync(localization);

			if (weather is null)
			{
				throw new MissingLocalizationWeatherException(localization);
			}

			var packingList = this.packingListFactory.CreatePackingListWithDefaultItems(id, name, localization, days, weather.Temperature, gender);
			
			await this.respository.AddAsync(packingList);
		}
	}
}

