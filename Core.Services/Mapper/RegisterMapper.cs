using AutoMapper;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.EntityModels;
using Data.ViewModels.DataUserVM;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Services.Mapper
{
    public class RegisterMapper : Profile
    {
        


        public RegisterMapper()
        {
            
            CreateMap<RegisterVm,User> ()
                .ForMember(x=>x.UserName,x=>x.MapFrom(x=>x.Email))
                .ForMember(x=>x.FirstName,x=>x.MapFrom(x=>x.FirstName))
                .ForMember (x=>x.LastName,x=>x.MapFrom(x=>x.LastName))
                .ForMember(x=>x.PhoneNumber,x=>x.MapFrom(x=>x.PhoneNumber))
                .ForMember(x=>x.ImageName,x=>x.MapFrom(x=> "Default.png"))
                .ForMember(x=>x.ImagePath,x=>x.MapFrom(x=>  "/Images/Default.png"))  
                .ReverseMap();



             
        }
    }
}
