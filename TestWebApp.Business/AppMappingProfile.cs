using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApp.Business.Models;
using TestWebApp.DataAccess.Entities;

namespace TestWebApp.Business
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<UserData, UserDataEntity>().ReverseMap();
        }
    }
}
