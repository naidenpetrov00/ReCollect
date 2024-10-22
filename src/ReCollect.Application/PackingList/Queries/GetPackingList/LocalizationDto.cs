namespace ReCollect.Application.PackingList.Queries.GetPackingList;

using AutoMapper;
using ReCollect.Domain.AggregatesModel.PackingAggregate.ValueObjects;

public class LocalizationDto
{
    public string? City { get; init; }

    public string? Country { get; init; }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Localization, LocalizationDto>();
        }
    }
}
