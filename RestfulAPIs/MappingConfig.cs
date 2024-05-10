using AutoMapper;
using RestfulAPIs.Models;
using RestfulAPIs.Models.DTOs;

namespace MagicVilla_VillaAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Resort, ResortDTO>();
            CreateMap<ResortDTO, Resort>();

            CreateMap<Resort, ResortCreateDTO>().ReverseMap();
            CreateMap<Resort, ResortUpdateDTO>().ReverseMap();


            CreateMap<ResortNumber, ResortDTO>().ReverseMap();
            CreateMap<ResortNumber, ResortCreateDTO>().ReverseMap();
            CreateMap<ResortNumber, ResortUpdateDTO>().ReverseMap();
            CreateMap<ApplicationUser, UserDTO>().ReverseMap();
        }
    }
}
