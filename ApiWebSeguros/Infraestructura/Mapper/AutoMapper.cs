using AutoMapper;
using ApiWebSeguros.Dominio.Entidades.DTOs; 
using ApiWebSeguros.Dominio;

namespace ApiWebSeguros.Infraestructura.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // TipoRoles
            CreateMap<TipoRolesToCreateDto, TipoRoles>();
            CreateMap<TipoRolesToUpdateDto, TipoRoles>();
            CreateMap<TipoRoles, TipoRolesDto>();

            // Ramo
            CreateMap<RamoToCreateDto, Ramo>();
            CreateMap<RamoToUpdateDto, Ramo>();
            CreateMap<Ramo, RamoToListDto>();

            // Poliza
            CreateMap<PolizaToCreateDto, Poliza>();
            CreateMap<PolizaToUpdateDto, Poliza>();
            CreateMap<Poliza, PolizaToListDto>();

            // Cliente
            CreateMap<ClienteToCreateDto, Cliente>();
            CreateMap<ClienteToUpdateDto, Cliente>();
            CreateMap<Cliente, ClienteToListDto>();
        }
    }
}
