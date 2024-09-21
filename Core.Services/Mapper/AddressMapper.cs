using AutoMapper;

using Data.EntityModels;
using Data.ViewModels.DataRESVM;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Mapper
{
    public class AddressMapper : Profile
    {
        public AddressMapper()
        {
            CreateMap<CreateVm, Address>()
                .ForMember(dest => dest.HoodId, opt => opt.MapFrom(src => src.HoodId))
                .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId))
                .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.CountryId));
        }
    }
}
