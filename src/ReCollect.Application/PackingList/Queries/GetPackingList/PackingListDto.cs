namespace ReCollect.Application.PackingList.Queries.GetPackingList;

using AutoMapper;
using ReCollect.Domain.AggregatesModel.PackingAggregate.Entities;

public class PackingListDto
{
    public int Id { get; init; }

    public string Name { get; init; }

    public LocalizationDto LocalizationDto { get; init; }

    public IEnumerable<PackingItemDto> Items { get; init; }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<PackingList, PackingListDto>();
        }
    }
}
