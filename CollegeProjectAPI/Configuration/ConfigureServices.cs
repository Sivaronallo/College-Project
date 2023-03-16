using CollegeProject.Api.Services;
using CollegeProject.Core.Interfaces;
using CollegeProject.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace CollegeProject.Api.Configuration;

public static class ConfigureServices
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddTransient<IEmailSender, EmailSender>();

        services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

        return services;
    }
}