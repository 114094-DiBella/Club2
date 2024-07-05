using AutoMapper;
using WebApplication1.Dtos;
using WebApplication1.Entities;
using WebApplication1.Repositories;

namespace WebApplication1.Mapper
{
    public class MappingProfile : Profile
    {

            public MappingProfile(){
                    
                CreateMap<UsuarioEntity, UserDto>();
                CreateMap<UserDto, UsuarioEntity>();
                CreateMap<DocenteDtoResponse, DocenteEntity>();
                CreateMap<DocenteEntity, DocenteDtoResponse>();
            }

    }
}
