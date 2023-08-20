using AutoMapper;
using Models;
using RegisterSchoolAPI.Dto;

namespace RegisterSchoolAPI.Tools
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<Usuario,DtoCreateUsuario>().ReverseMap();
            CreateMap<Usuario, DtoUpdateUsuario>().ReverseMap();
        }
    }
}
