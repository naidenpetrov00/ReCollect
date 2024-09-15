namespace ReCollect.Application.PackingList.Queries.GetPackingList;

using AutoMapper;
using ReCollect.Domain.AggregatesModel.PackingAggregate.Entities;

public class PackingItemDto
{
    public string Name { get; init; }
    public uint Quantity { get; init; }
    public bool IsPacked { get; init; }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<PackingItem, PackingItemDto>();
        }
    }
}
