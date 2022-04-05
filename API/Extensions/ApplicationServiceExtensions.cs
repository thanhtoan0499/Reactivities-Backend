using Application.Activities;
using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions 
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<ReactContext>(opt =>
            {
                opt.UseSqlite("Data Source=reactivities.db");
                //opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddMediatR(typeof(List.Handler).Assembly);
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            return services;
        }
    }
}
