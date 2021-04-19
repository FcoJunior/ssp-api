using System;
using SSP.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SSP.Domain.Repository;
using SSP.Infra.Data.Repository;
using SSP.Domain.AppService;
using SSP.Application.Service.AppService;

namespace SSP.Infra.CrossCutting
{
    public static class Bootstrapper
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration){
            services.AddAutoMapper(o => o.AddProfile(new AutoMapperProfile()));

            services.AddScoped<IUserAppService, UserAppService>();

            services.AddScoped<IUserRepository, UserRepository>();
            
            var connectionString = configuration.GetConnectionString("Context");
            services.AddDbContext<Context>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IContext, Context>();
        }
    }
}
