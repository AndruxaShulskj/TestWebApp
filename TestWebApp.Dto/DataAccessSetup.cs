using Microsoft.Extensions.DependencyInjection;
using TestWebApp.Business.Interfaces;
using TestWebApp.Business.Services;

namespace TestWebApp.Dto
{
    public static class DtoSetup
    {
        public static void RegisterDto(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AppMappingProfile));
        }
    }
}
