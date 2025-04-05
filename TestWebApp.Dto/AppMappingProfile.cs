using AutoMapper;
using TestWebApp.Business.Models;
using TestWebApp.Dto.Models;

namespace TestWebApp.Dto
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<UserData, UserDto>().ReverseMap();
        }
    }
}
