using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.ViewModels.DataUserVM;

namespace Core.Services.Mapper
{
    public  class RegisterToLogin:Profile
    {
        public RegisterToLogin()
        {
            CreateMap<RegisterVm,LoginVm>().ForMember(x=>x.Email,x=>x.MapFrom(x=>x.Email))
                .ForMember(x=>x.Password,x=>x.MapFrom(x=>x.Password))
                .ForMember(x=>x.RememberMe,x=>x.MapFrom(x=>true)).ReverseMap();
        }
    }
}
