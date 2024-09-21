using AutoMapper;
using Data.EntityModels;
using Data.ViewModels.DataRESVM;


namespace Core.Services.Mapper
{
    public class CardMapper : Profile
    {
        public CardMapper()
        {

            CreateMap<RealEs, CardVm>()
                .ForMember(dest => dest.ImageName, opt => opt.MapFrom(src => src.Images.Select(x => x.ImageName).ToList())) // Map as a List<string>
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country.Name))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City.Name))
                .ForMember(dest => dest.Hood, opt => opt.MapFrom(src => src.Address.Hood.Name))
                .ForMember(dest => dest.AreaSiza, opt => opt.MapFrom(src => src.AreaSize))
                .ForMember(dest => dest.UserPp, opt => opt.MapFrom(src => src.User.ImageName))
                .ForMember(dest => dest.TotalRooms, opt => opt.MapFrom(src => src.Room.NBathroom))
                .ForMember(dest => dest.NBedRoom, opt => opt.MapFrom(src => src.Room.NBedroom))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.CreatedAt.ToShortDateString()))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.RealId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

        }
    }
}