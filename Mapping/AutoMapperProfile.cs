using AutoMapper;
using Lingo.Model.Domain;
using Lingo.Model.Dto;

namespace Lingo.Mapping
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Slang, GetSlangsDto>().ReverseMap();
            CreateMap<Slang, AddSlangRequestDto>().ReverseMap();
            CreateMap<Country, GetCountriesDto>().ReverseMap();
            CreateMap<Country, AddCountriesDto>().ReverseMap();

        }

    }
}
