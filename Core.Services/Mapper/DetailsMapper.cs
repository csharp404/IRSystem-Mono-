using AutoMapper;
using System.Linq;
using Data.EntityModels;
using Data.ViewModels.DataRESVM;

namespace Core.Services.Mapper
{
    public class DetailsMapper : Profile
    {
        public DetailsMapper()
        {
            CreateMap<RealEs, DetailsVm>()
                .ForMember(dest => dest.ImageName, opt => opt.MapFrom(src => src.Images.Select(x => x.ImageName).ToList()))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country.Name))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City.Name))
                .ForMember(dest => dest.Hood, opt => opt.MapFrom(src => src.Address.Hood.Name))
                .ForMember(dest => dest.NBedRoom, opt => opt.MapFrom(src => src.Room.NBedroom)) // Correcting "Room" to "Rooms"
                .ForMember(dest => dest.TotalRooms, opt => opt.MapFrom(src => src.Room.NRooms))   // Correcting "Room" to "Rooms"
                .ForMember(dest => dest.NBathrooms, opt => opt.MapFrom(src => src.Room.NBathroom)) // Correcting "Room" to "Rooms"
                .ForMember(dest => dest.AreaSiza, opt => opt.MapFrom(src => src.AreaSize))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName)) // Correcting "user" to "src.User"
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.CreatedAt.Year.ToString()))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.Garage, opt => opt.MapFrom(src => src.Room.NGarage)) // Correcting "Room" to "Rooms"
                .ForMember(dest => dest.UserPp, opt => opt.MapFrom(src => src.User.ImageName))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.User.PhoneNumber)) // Correcting "user" to "src.User"
                .ForMember(dest => dest.Features, opt => opt.MapFrom(src => src.RealEsFeatures.Select(x => x.Feature.Name).ToList()))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(x=>x.UserId))
                .ForMember(dest => dest.RealId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Commentslist, opt => opt.MapFrom(src => src.Comments.Select(x => new Comments
                {
                    CreatedAt = x.CreatedAt,
                    Description = x.Description,
                    User = x.User,
                    UserId = x.UserId,
                    RealEsid = x.RealEsid
                }).OrderByDescending(x => x.CreatedAt).ToList()))
                .ForMember(dest => dest.Views, opt => opt.MapFrom(src => src.Views));
        }
    }
}
