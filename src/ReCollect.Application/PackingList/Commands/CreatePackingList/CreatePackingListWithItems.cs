namespace ReCollect.Application.PackingList.Commands.CreatePackingList;

using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using MediatR;
using ReCollect.Application.Services;
using ReCollect.Domain.AggregatesModel.PackingAggregate;
using ReCollect.Domain.Enums;
using ReCollect.Domain.ValueObjects.PackingLists;

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
    private readonly IPackingListRepository repository;
    private readonly IWeatherService weatherService;

    public CreatePackingListWithItemsHandler(
        IPackingListRepository repository,
        IWeatherService weatherService
    )
    {
        this.repository = repository;
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
    }
}
