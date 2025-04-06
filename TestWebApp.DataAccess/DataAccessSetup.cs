using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TestWebApp.Common;
using TestWebApp.DataAccess.Interfaces;
using TestWebApp.DataAccess.Repositories;

namespace TestWebApp.DataAccess
{
    public static class DataAccessSetup
    {
        public static void RegisterDataAccess(this IServiceCollection services)
        {
            var connectionString = ConfigurationGetter.GetConnectionString();

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlite(connectionString,
                    x => x.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)))
                
                .AddScoped<IUserDataRepository, UserDataRepository>()
                .AddScoped<ILogRepository, LogRepository>();
        }

        public static void DatabaseMigration(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            context.Database.Migrate();

        }
    }
}
