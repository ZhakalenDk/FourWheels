using ITGuru.FourWheels.Data;
using Microsoft.Extensions.DependencyInjection;

namespace ITGuru.FourWheels.Service
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="IDataLayer"/> as a <strong>Singleton</strong> instance
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddContext(this IServiceCollection services)
        {
            IDataLayer data = new DataLayer();
            return services.AddSingleton<IDataLayer>(data);
        }

        /// <summary>
        /// Add <see cref="ICustomerService"/> and <see cref="IVehicleService"/> as <strong>scoped</strong> services
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddScoped<ICustomerService, CustomerService>();
            service.AddScoped<IVehicleService, VehicleService>();

            ServiceDefinitions.Services = service.BuildServiceProvider();   //  Collecting provider for use in non-service access points

            return service;
        }
    }
}
