using AutoMapper;
using PlutonBE;

namespace PlutonUI.Models
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {

            CreateMap<ProveedorModel, Proveedor>();
            CreateMap<Proveedor, ProveedorModel>();
        }

    }
}
