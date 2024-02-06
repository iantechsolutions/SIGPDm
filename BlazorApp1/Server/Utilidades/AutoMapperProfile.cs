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

            #region Prestamo
            CreateMap<Prestamo, PrestamoDTO>();
            CreateMap<PrestamoDTO, Prestamo>();
            #endregion Prestamo

            #region Personal
            CreateMap<Personal, PersonalDTO>();
            CreateMap<PersonalDTO, Personal>();
            #endregion Personal

        }
    }
}
