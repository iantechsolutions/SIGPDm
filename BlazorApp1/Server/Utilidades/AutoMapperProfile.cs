using AutoMapper;
using BlazorApp1.Shared.Models;
using BlazorApp1.Server.Models;

namespace BlazorApp1.Server.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region OC
            CreateMap<Ordencompra, OrdencompraDTO>();
            CreateMap<OrdencompraDTO, Ordencompra>();
            #endregion OC

            #region Insumo
            CreateMap<Insumo, InsumoDTO>();
            CreateMap<InsumoDTO, Insumo>();
            #endregion Insumo
            
            #region Proovedores
            CreateMap<Proveedore, ProveedoreDTO>();
            CreateMap<ProveedoreDTO, Proveedore>();
            #endregion Proovedores
        }
    }
}
