using AutoMapper;
using GRWalks.API.Models.Domain;
using GRWalks.API.Models.DTO;

namespace GRWalks.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDto>().ReverseMap();

            CreateMap<AddRegionDto, Region>().ReverseMap();

            CreateMap<UpdateRegionDto, Region>().ReverseMap();
        }
    }
}
