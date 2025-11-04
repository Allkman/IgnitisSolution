using Ignitis.Services;

namespace Ignitis.Api
{
    public static class IocDependencies
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IPowerPlantService, PowerPlantService>();

            return services;
        }
    }
}
