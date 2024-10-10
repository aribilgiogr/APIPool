using Business.Services;
using Core.Abstracts;
using Core.Abstracts.IServices;
using Data;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class IOC
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddSingleton<IEarthquakesService,EarthquakesService>();
            services.AddSingleton<ICurrencyService,CurrencyService>();
            return services;
        }

        public static IServiceCollection AddShelfDataConnection(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ShelfContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("shelf")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IShelfService, ShelfService>();
            return services;
        }
    }
}
