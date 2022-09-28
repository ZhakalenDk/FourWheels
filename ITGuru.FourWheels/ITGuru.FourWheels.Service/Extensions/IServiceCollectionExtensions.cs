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
            return services.AddSingleton<IDataLayer, Data.DataLayer>();
        }
    }
}
