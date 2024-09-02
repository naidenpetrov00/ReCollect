namespace PackIT.Application.PackingList.Commands.CreatePackingList;

using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using MediatR;
using PackIT.Application.Services;
using PackIT.Domain.AggregatesModel.PackingAggregate;
using PackIT.Domain.Enums;
using PackIT.Domain.Factory;
using PackIT.Domain.ValueObjects.PackingLists;

public record CreatePackingListWithItems(
    Guid Id,
    string Name,
    ushort Days,
    Gender Gender,
    LocalizationWriteModel Localization
) : IRequest;

public record LocalizationWriteModel(string City, string Country);

public class CreatePackingListWithItemsHandler : IRequestHandler<CreatePackingListWithItems>
{
    private readonly IPackingListReository repository;
    private readonly IPackingListFactory packingListFactory;
    private readonly IWeatherService weatherService;

    public CreatePackingListWithItemsHandler(
        IPackingListRepository repository,
        IPackingListFactory packingListFactory,
        IWeatherService weatherService
    )
    {
        this.repository = repository;
        this.packingListFactory = packingListFactory;
        this.weatherService = weatherService;
    }

    public async Task Handle(
        CreatePackingListWithItems request,
        CancellationToken cancellationToken
    )
    {
        var (id, name, days, gender, localizationWriteModel) = request;

        var localization = new Localization(
            request.Localization.City,
            request.Localization.Country
        );
        var weather = await this.weatherService.GetWeatherAsync(localization);
        Guard.Against.Null(weather);

        var packingList = this.packingListFactory.CreatePackingListWithDefaultItems(
            id,
            name,
            localization,
            days,
            weather.Temperature,
            gender
        );
        await this.repository.AddAsync(packingList);
    }
}
