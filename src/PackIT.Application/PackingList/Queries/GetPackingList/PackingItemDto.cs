namespace PackIT.Application.Common.DTO;

using AutoMapper;
using PackIT.Domain.ValueObjects.PackingItems;

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
