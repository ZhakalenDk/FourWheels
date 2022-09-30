using ITGuru.FourWheels.Data;
using ITGuru.FourWheels.Service.Repos;
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
            service.AddScoped<ITaskService, TaskService>();

            return service;
        }
    }
}
