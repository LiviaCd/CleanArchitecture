using AutoMapper;
using eBlog.Domain.Repository;
using eBlog.Infrastructure.Data;
using eBlog.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Functions;
using Shared.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBlog.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BlogDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("BlogDbContext") 
                )
            );

            services.AddTransient<IBlogRepository, BlogRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork<BlogDbContext>>();
            services.AddScoped<AddPhoto>();

            return services;
        }
    }
}
