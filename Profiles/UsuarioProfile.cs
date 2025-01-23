using AutoMapper;
using Identity.API.Data.DTO;
using Identity.API.Models;

namespace Identity.API.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<CreateUsuarioDTO, Usuario>();
    }
}
