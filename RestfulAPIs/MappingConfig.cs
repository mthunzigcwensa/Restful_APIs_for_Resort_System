using AutoMapper;
using RestfulAPIs.Models;
using RestfulAPIs.Models.DTOs;

namespace RestfulAPIs
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Resort, ResortDTO>();
            CreateMap<ResortDTO, Resort>();

            CreateMap<Resort, ResortCreateDTO>().ReverseMap();
            CreateMap<Resort, ResortUpdateDTO>().ReverseMap();


            CreateMap<ResortNumber, ResortNumberDTO>().ReverseMap();
            CreateMap<ResortNumber, ResortNumberCreateDTO>().ReverseMap();
            CreateMap<ResortNumber, ResortNumberUpdateDTO>().ReverseMap();
            CreateMap<ApplicationUser, UserDTO>().ReverseMap();
        }
    }
}
