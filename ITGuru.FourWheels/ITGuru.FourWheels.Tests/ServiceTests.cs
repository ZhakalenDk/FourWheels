using ITGuru.FourWheels.Service;
using Microsoft.Extensions.DependencyInjection;

namespace ITGuru.FourWheels.Tests
{
    public class ServiceTests
    {
        [Fact]
        public void GetAllServices()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddServices();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Act
            var customerService = serviceProvider.GetService<ICustomerService>();
            var vehicleService = serviceProvider.GetService<IVehicleService>();

            // Assert
            Assert.NotNull(customerService);
            Assert.NotNull(vehicleService);
        }
    }
}
