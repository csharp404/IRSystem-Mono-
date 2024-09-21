using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.EntityModels;
using Data.ViewModels.DataRESVM;

namespace Core.Services.Mapper
{
    public class FavoriteMapper:Profile
    {
        public FavoriteMapper()
        {
            
        CreateMap<RealEs, FavVm>()
            .ForMember(dest => dest.RealId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.ImageName, opt => opt.MapFrom(src => src.Images.FirstOrDefault().ImageName))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country.Name))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City.Name))
            .ForMember(dest => dest.Hood, opt => opt.MapFrom(src => src.Address.Hood.Name));
        }
      

    }
}
