namespace ReCollect.Application.Common.DTO;

using AutoMapper;
using ReCollect.Application.SeedWork.Models;
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
