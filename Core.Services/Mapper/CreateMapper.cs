using AutoMapper;
using Data.EntityModels;
using Data.ViewModels.DataRESVM;

namespace Core.Services.Mapper
{
    public class CreateMapper : Profile
    {
        public CreateMapper()
        {
            CreateMap<RealEs, CreateVm>()
                .ForMember(dest => dest.Features, opt => opt.MapFrom(src => src.RealEsFeatures.Select(r =>
                    new SelectionFeatures
                    {
                        Id = r.FeatureId,
                        Name = r.Feature.Name, 
                        IsSelected = true
                    }).ToList()))
                .ForMember(dest => dest.IdRealEs, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.IdAddress, opt => opt.MapFrom(src => src.AddressId))
                .ForMember(dest => dest.IdRoom, opt => opt.MapFrom(src => src.RoomId))
                .ForMember(dest => dest.AreaSize, opt => opt.MapFrom(src => src.AreaSize))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.Address.CountryId))
                .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.Address.CityId))
                .ForMember(dest => dest.HoodId, opt => opt.MapFrom(src => src.Address.HoodId))
                .ForMember(dest => dest.NRooms, opt => opt.MapFrom(src => src.Room.NRooms))
                .ForMember(dest => dest.NBedroom, opt => opt.MapFrom(src => src.Room.NBedroom))
                .ForMember(dest => dest.NBathroom, opt => opt.MapFrom(src => src.Room.NBathroom))
                .ForMember(dest => dest.Carage, opt => opt.MapFrom(src => src.Room.NGarage))
                .ForMember(dest => dest.NFloors, opt => opt.MapFrom(src => src.Room.NFloors))
                .ForMember(dest => dest.NKitchen, opt => opt.MapFrom(src => src.Room.NKitchen))
                .ForMember(dest => dest.NLivingRoom, opt => opt.MapFrom(src => src.Room.NLivingRoom))
                .ForMember(dest => dest.YearBuilt, opt => opt.MapFrom(src => src.YearBuilt))
                .ForMember(dest => dest.UserId, opt => opt.Ignore()) // Assuming UserID is set manually later
                .ForMember(dest => dest.Flag, opt => opt.MapFrom(src => true)).ReverseMap();
        }
    }
}
