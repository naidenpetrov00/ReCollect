namespace PackIT.Application.SeedWork.Models
{
    using AutoMapper;
    using PackIT.Domain.ValueObjects.PackingLists;

    public class LocalizationDto
    {
        public string City { get; init; }

        public string Country { get; init; }

        public class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Localization, LocalizationDto>();
            }
        }
    }
}
