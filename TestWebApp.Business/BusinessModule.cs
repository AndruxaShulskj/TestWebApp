using Microsoft.Extensions.DependencyInjection;
using TestWebApp.Business.Interfaces;
using TestWebApp.Business.Services;

namespace TestWebApp.Business;

public static class BusinessModule
{
    public static void RegisterBusiness(this IServiceCollection services)
    {
        services.AddTransient<IUserDataService, UserDataService>()
            .AddTransient<ILogDataService, LogDataService>()
            .AddAutoMapper(typeof(AppMappingProfile)); ;
    }
}