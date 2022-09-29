using ITGuru.FourWheels.Data;
using ITGuru.FourWheels.Service;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.ComponentModel.DataAnnotations;
using System.Xml;
using ITGuru.FourWheels.Data.DataModels;
using Microsoft.Extensions.DependencyInjection;

namespace ITGuru.FourWheels.Tests.RepositoryTests
{
    public class VehicleRepositoryTests
    {
        private static readonly Guid _DEFAULT_VEHICLE_ID = Guid.NewGuid();

        private static readonly ICustomer _DEFAULT_CUSTOMER = new CustomerDTO
        {
            Id = Guid.NewGuid(),
            FirstName = "Customer",
            LastName = "0",
            Phone = "00000000",
            Email = "test@itguru.com"
        };
        private static readonly ICustomer _DEFAULT_CUSTOMER_1 = new CustomerDTO
        {
            Id = Guid.NewGuid(),
            FirstName = "Customer",
            LastName = "1",
            Phone = "11111111",
            Email = "test@itguru.com"
        };

        private static readonly IVehicle _DEFAULT_VEHICLE = new VehicleDTO
        {
            Id = _DEFAULT_VEHICLE_ID,
            Brand = "Lucid",
            Model = "Air",
            LicensePlate = "AA 69 420",
            CustomerId = _DEFAULT_CUSTOMER.Id
        };
        private static readonly IVehicle _DEFAULT_VEHICLE_EDITED = new VehicleDTO
        {
            Id = _DEFAULT_VEHICLE_ID,
            Brand = "Tesla",
            Model = "Model Y",
            LicensePlate = "BB 96 024",
            CustomerId = _DEFAULT_CUSTOMER_1.Id
        };
        private static readonly IVehicle _DEFAULT_VEHICLE_1 = new VehicleDTO
        {
            Id = Guid.NewGuid(),
            Brand = "Volkswagen",
            Model = "ID.3",
            LicensePlate = "CC 12 345",
            CustomerId = _DEFAULT_CUSTOMER.Id
        };
        private static readonly IVehicle _DEFAULT_VEHICLE_2 = new VehicleDTO
        {
            Id = Guid.NewGuid(),
            Brand = "Tesla",
            Model = "Model S",
            LicensePlate = "DD 22 222",
            CustomerId = _DEFAULT_CUSTOMER_1.Id
        };

        private static readonly List<IVehicle> _VEHICLES = new()
        {
            _DEFAULT_VEHICLE,
            _DEFAULT_VEHICLE_1,
            _DEFAULT_VEHICLE_2
        };

        private VehicleService _vehicleRepository;

        public VehicleRepositoryTests()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddServices();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            _vehicleRepository = serviceProvider.GetService<IVehicleService>() as VehicleService;
        }

        [Fact]
        public void AddAndGetVehicleTest()
        {
            // Arrange

            // Act
            // Save vehicle in repository.
            var addResult = _vehicleRepository.Add(_DEFAULT_VEHICLE);

            // Retrieve the newly created vehicle from the repository.
            var createdVehicle = _vehicleRepository.GetById(_DEFAULT_VEHICLE.Id);

            // Assert
            Assert.True(addResult.Succeeded);
            Assert.NotNull(createdVehicle);
            AssertAllVehicleProperties(_DEFAULT_VEHICLE, createdVehicle);
        }

        [Fact]
        public void AddAndDeleteVehicleTest()
        {
            // 1. Create
            // Arrange

            // Act
            var addResult = _vehicleRepository.Add(_DEFAULT_VEHICLE);
            var createdVehicle = _vehicleRepository.GetById(_DEFAULT_VEHICLE.Id);

            // Assert
            Assert.True(addResult.Succeeded);
            Assert.NotNull(createdVehicle);
            AssertAllVehicleProperties(_DEFAULT_VEHICLE, createdVehicle);

            // 2. Delete
            // Act
            var removeResult = _vehicleRepository.Remove(createdVehicle);
            var deletedVehicle = _vehicleRepository.GetById(createdVehicle.Id);

            // Assert
            Assert.True(removeResult.Succeeded);
            Assert.Null(deletedVehicle);
        }

        [Fact]
        public void AddAndUpdateVehicleTest()
        {
            // 1. Create
            // Arrange
            var createVehicle = _DEFAULT_VEHICLE;
            var editVehicle = _DEFAULT_VEHICLE_EDITED;

            // Act
            var addResult = _vehicleRepository.Add(createVehicle);
            var createdVehicle = _vehicleRepository.GetById(createVehicle.Id);

            // Assert
            Assert.True(addResult.Succeeded);
            Assert.NotNull(createdVehicle);
            AssertAllVehicleProperties(createVehicle, createdVehicle);

            // 2. Update
            // Act
            var updateResult = _vehicleRepository.Update(editVehicle);
            var editedVehicle = _vehicleRepository.GetById(createdVehicle.Id);

            // Assert
            Assert.True(updateResult.Succeeded);
            Assert.NotNull(editedVehicle);
            AssertAllVehicleProperties(editVehicle, editedVehicle);
        }

        [Fact]
        public void AddDublicateVehicleTest()
        {
            // Arrange

            // Act
            _vehicleRepository.Add(_DEFAULT_VEHICLE);
            _vehicleRepository.Add(_DEFAULT_VEHICLE);
            _vehicleRepository.Add(_DEFAULT_VEHICLE);

            var allVehicles = _vehicleRepository.GetAll();

            // Assert
            var returnedVehicles = allVehicles.Where(c => c.Id == _DEFAULT_VEHICLE.Id);
            Assert.NotNull(returnedVehicles.FirstOrDefault());
            Assert.Single(returnedVehicles);
        }

        [Fact]
        public void GetAllVehicles()
        {
            // Arrange
            var vehiclesToCreate = new List<IVehicle>()
            {
                _DEFAULT_VEHICLE,
                _DEFAULT_VEHICLE_1,
                _DEFAULT_VEHICLE_2
            };

            bool addAllSuccess = true;
            foreach (var vehicle in vehiclesToCreate)
            {
                addAllSuccess = _vehicleRepository.Add(vehicle).Succeeded && addAllSuccess;
            }

            // Act
            var retrievedVehicles = _vehicleRepository.GetAll();

            // Assert
            Assert.True(addAllSuccess);

            foreach (var vehicle in vehiclesToCreate)
            {
                // Assert: Vehicle is present and data is correct.
                var retrievedVehicle = retrievedVehicles.Where(c => c.Id == vehicle.Id).FirstOrDefault();
                Assert.NotNull(retrievedVehicle);
                AssertAllVehicleProperties(vehicle, retrievedVehicle);

                // Assert: Vehicle is present once only.
                Assert.Single(retrievedVehicles.Where(c => c.Id == vehicle.Id));
            }
        }

        [Fact]
        public void DeleteNonExistingVehicleTest()
        {
            // Arrange

            // Act
            var result = _vehicleRepository.Remove(_DEFAULT_VEHICLE);

            // Assert
            Assert.False(result.Succeeded);
        }

        [Fact]
        public void GetVehiclesThroughCustomerTest()
        {
            // Arrange
            var customer0Vehicles = _VEHICLES.Where(v => v.CustomerId == _DEFAULT_CUSTOMER.Id);
            var customer1Vehicles = _VEHICLES.Where(v => v.CustomerId == _DEFAULT_CUSTOMER_1.Id);

            // Act
            var retrievedCustomer0Vehicles = _DEFAULT_CUSTOMER.GetVehicles();
            var retrievedCustomer1Vehicles = _DEFAULT_CUSTOMER_1.GetVehicles();

            // Assert
            Assert.NotNull(retrievedCustomer0Vehicles);
            Assert.NotNull(retrievedCustomer1Vehicles);

            foreach(var actualVehicle in retrievedCustomer0Vehicles)
            {
                var expectedVehicle = customer0Vehicles.Where(v => v.Id == actualVehicle.Id).FirstOrDefault();
                Assert.NotNull(expectedVehicle);
                AssertAllVehicleProperties(expectedVehicle, actualVehicle);
            }
        }

        private void AssertAllVehicleProperties(IVehicle exptectedVehicle, IVehicle actualVehicle)
        {
            Assert.Equal(exptectedVehicle.Id, actualVehicle.Id);
        }
    }
}
