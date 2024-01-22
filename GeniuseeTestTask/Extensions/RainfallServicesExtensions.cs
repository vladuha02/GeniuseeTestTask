using GeniuseeTestTask.Abstractions;
using GeniuseeTestTask.Services;

namespace GeniuseeTestTask.Extensions
{
    public static class RainfallServicesExtensions
    {
        public static void AddRainfallServices(this IServiceCollection services)
        {
            services.AddScoped<IRainfallServices, RainfallServices>();
            services.AddScoped<IValidateInputDataServices, ValidateInputDataServices>();
        }
    }
}
