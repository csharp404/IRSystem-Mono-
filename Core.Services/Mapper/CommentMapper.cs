using AutoMapper;
using Data.EntityModels;
using Data.ViewModels.DataRESVM;



namespace Core.Services.Mapper
{
    public class CommentMapper:Profile
    {
        public CommentMapper()
        {
            CreateMap<DetailsVm, Comments>()
                .ForMember(x=>x.Id,x=>x.MapFrom(x=>Guid.NewGuid().ToString()))
                .ForMember(x=>x.Description,x=>x.MapFrom(x=>x.Comment))
                .ForMember(x=>x.UserId,x=>x.MapFrom(x=>x.UserId))
                .ForMember(x=>x.RealEsid,x=>x.MapFrom(x=>x.RealId))
                .ForMember(x=>x.CreatedAt,x=>x.MapFrom(x=>DateTime.Now)).ReverseMap();
           
        }
    }
}
