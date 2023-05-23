using Core.Interfaces;
using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Repostories;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", policy =>
            {
                policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
            });
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));

        services.AddDbContext<StudentPanelContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("StudentAdminPortalDb"));
        });

        return services;
    }
}