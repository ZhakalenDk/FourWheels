using ITGuru.FourWheels.Data;
using Microsoft.Extensions.DependencyInjection;

namespace ITGuru.FourWheels.Service
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Add <see cref="ICustomerService"/> and <see cref="IVehicleService"/> as <strong>scoped</strong> services
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddScoped<ICustomerService, CustomerService>();
            service.AddScoped<IVehicleService, VehicleService>();

            return service;
        }
    }
}
