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
    public class RoomMapper : Profile
    {
        public RoomMapper()
        {
             CreateMap<CreateVm, Room>()
                 .ForMember(dest => dest.NBathroom, opt => opt.MapFrom(src => src.NBathroom))
                 .ForMember(dest => dest.NBedroom, opt => opt.MapFrom(src => src.NBedroom))
                 .ForMember(dest => dest.NGarage, opt => opt.MapFrom(src => src.Carage))
                 .ForMember(dest => dest.NFloors, opt => opt.MapFrom(src => src.NFloors))
                 .ForMember(dest => dest.NKitchen, opt => opt.MapFrom(src => src.NKitchen))
                 .ForMember(dest => dest.NLivingRoom, opt => opt.MapFrom(src => src.NLivingRoom))
                 .ForMember(dest => dest.NRooms, opt => opt.MapFrom(src => src.NRooms))
;




     
        }
    }
}
