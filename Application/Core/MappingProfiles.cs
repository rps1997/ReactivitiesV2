using AutoMapper;
using Domain;
using Domain.DTO;

namespace API.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Activity, Activity>();
            CreateMap<UpdateActivityDto, Activity>();
        }
    }
}
