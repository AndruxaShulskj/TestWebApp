﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestWebApp.Common;
using System.Reflection;
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
                
                .AddScoped<IUserDataRepository, UserDataRepository>();
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
