using AutoMapper;
using Domain;
using Domain.DTO;

namespace API
{
    public class ActivityProfile : Profile
    {
        public ActivityProfile()
        {
            CreateMap<UpdateActivityDto, Activity>();
        }
    }
}
