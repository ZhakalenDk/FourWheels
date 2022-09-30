using ITGuru.FourWheels.Data;
using ITGuru.FourWheels.Service;

namespace ITGuru.FourWheels.Tests.RepositoryTests
{
    public class VehicleRepositoryTests : IDisposable
    {
//#pragma warning disable IDE1006 // Naming Styles - It doesn't make sense to use Pascal, as the member is more visible in upper case.
//        private static readonly Guid _DEFAULT_VEHICLE_ID = Guid.NewGuid();

//        private static readonly ICustomer _DEFAULT_CUSTOMER = new CustomerDTO
//        {
//            Id = Guid.NewGuid(),
//            FirstName = "Customer",
//            LastName = "0",
//            Phone = "00000000",
//            Email = "test@itguru.com"
//        };
//        private static readonly ICustomer _DEFAULT_CUSTOMER_1 = new CustomerDTO
//        {
//            Id = Guid.NewGuid(),
//            FirstName = "Customer",
//            LastName = "1",
//            Phone = "11111111",
//            Email = "test@itguru.com"
//        };

//        private static readonly IVehicle _DEFAULT_VEHICLE = new VehicleDTO
//        {
//            Id = _DEFAULT_VEHICLE_ID,
//            Brand = "Lucid",
//            Model = "Air",
//            LicensePlate = "AA 69 420",
//            CustomerId = _DEFAULT_CUSTOMER.Id
//        };
//        private static readonly IVehicle _DEFAULT_VEHICLE_EDITED = new VehicleDTO
//        {
//            Id = _DEFAULT_VEHICLE_ID,
//            Brand = "Tesla",
//            Model = "Model Y",
//            LicensePlate = "BB 96 024",
//            CustomerId = _DEFAULT_CUSTOMER_1.Id
//        };
//        private static readonly IVehicle _DEFAULT_VEHICLE_1 = new VehicleDTO
//        {
//            Id = Guid.NewGuid(),
//            Brand = "Volkswagen",
//            Model = "ID.3",
//            LicensePlate = "CC 12 345",
//            CustomerId = _DEFAULT_CUSTOMER.Id
//        };
//        private static readonly IVehicle _DEFAULT_VEHICLE_2 = new VehicleDTO
//        {
//            Id = Guid.NewGuid(),
//            Brand = "Tesla",
//            Model = "Model S",
//            LicensePlate = "DD 22 222",
//            CustomerId = _DEFAULT_CUSTOMER_1.Id
//        };

//        private static readonly List<IVehicle> _VEHICLES = new()
//        {
//            _DEFAULT_VEHICLE,
//            _DEFAULT_VEHICLE_1,
//            _DEFAULT_VEHICLE_2
//        };
//#pragma warning restore IDE1006 // Naming Styles

        private IVehicleService _vehicleRepository;

        public VehicleRepositoryTests()
        {
            DataLayer.WipeData();

            _vehicleRepository = new VehicleService();
        }

        public void Dispose()
        {
            DataLayer.WipeData();
        }

        [Fact]
        public void AddAndGetVehicleTest()
        {
            // Arrange
            IVehicle toAddVehicle = new VehicleDTO
            {
                Id = Guid.NewGuid(),
                Brand = "Lucid",
                Model = "Air",
                LicensePlate = "AA 69 420"
            };

            // Act
            // Save vehicle in repository.
            var addResult = _vehicleRepository.Add(toAddVehicle);

            // Retrieve the newly created vehicle from the repository.
            var addedVehicle = _vehicleRepository.GetById(toAddVehicle.Id);

            // Assert
            Assert.True(addResult.Succeeded);
            Assert.NotNull(addedVehicle);
            AssertAllVehicleProperties(toAddVehicle, addedVehicle);
        }

        [Fact]
        public void AddAndRemoveVehicleTest()
        {
            // 1. Create
            // Arrange
            IVehicle toAddVehicle = new VehicleDTO
            {
                Id = Guid.NewGuid(),
                Brand = "Lucid",
                Model = "Air",
                LicensePlate = "AA 69 420"
            };

            // Act
            var addResult = _vehicleRepository.Add(toAddVehicle);
            var addedVehicle = _vehicleRepository.GetById(toAddVehicle.Id);

            // Assert
            Assert.True(addResult.Succeeded);
            Assert.NotNull(addedVehicle);
            AssertAllVehicleProperties(toAddVehicle, addedVehicle);

            // 2. Delete
            // Act
            var removeResult = _vehicleRepository.Remove(addedVehicle);
            var removedVehicle = _vehicleRepository.GetById(addedVehicle.Id);

            // Assert
            Assert.True(removeResult.Succeeded);
            Assert.Null(removedVehicle);
        }

        [Fact]
        public void AddAndUpdateVehicleTest()
        {
            // 1. Create
            // Arrange
            var vehicleId = Guid.NewGuid();
            var toAddVehicle = new VehicleDTO
            {
                Id = vehicleId,
                Brand = "Lucid",
                Model = "Air",
                LicensePlate = "AA 69 420"
            };
            var toUpdateVehicle = new VehicleDTO
            {
                Id = vehicleId,
                Brand = "Tesla",
                Model = "Model Y",
                LicensePlate = "BB 96 024",
            };

            // Act
            var addResult = _vehicleRepository.Add(toAddVehicle);
            var createdVehicle = _vehicleRepository.GetById(toAddVehicle.Id);

            // Assert
            Assert.True(addResult.Succeeded);
            Assert.NotNull(createdVehicle);
            AssertAllVehicleProperties(toAddVehicle, createdVehicle);

            // 2. Update
            // Act
            var updateResult = _vehicleRepository.Update(toUpdateVehicle);
            var editedVehicle = _vehicleRepository.GetById(createdVehicle.Id);

            // Assert
            Assert.True(updateResult.Succeeded);
            Assert.NotNull(editedVehicle);
            AssertAllVehicleProperties(toUpdateVehicle, editedVehicle);
        }

        [Fact]
        public void AddDublicateVehicleTest()
        {
            // Arrange
            var toAddVehicle = new VehicleDTO
            {
                Id = Guid.NewGuid(),
                Brand = "Lucid",
                Model = "Air",
                LicensePlate = "AA 69 420"
            };

            // Act
            _vehicleRepository.Add(toAddVehicle);
            _vehicleRepository.Add(toAddVehicle);
            _vehicleRepository.Add(toAddVehicle);

            var allVehicles = _vehicleRepository.GetAll();

            // Assert
            var returnedVehicles = allVehicles.Where(c => c.Id == toAddVehicle.Id);
            Assert.NotNull(returnedVehicles.FirstOrDefault());
            Assert.Single(returnedVehicles);
        }

        [Fact]
        public void GetAllVehicles()
        {
            // Arrange
            var vehiclesToCreate = new List<IVehicle>()
            {
                new VehicleDTO
                {
                    Id = Guid.NewGuid(),
                    Brand = "Lucid",
                    Model = "Air",
                    LicensePlate = "AA 69 420"
                },
                new VehicleDTO
                {
                    Id = Guid.NewGuid(),
                    Brand = "Volkswagen",
                    Model = "ID.3",
                    LicensePlate = "CC 12 345"
                },
                new VehicleDTO
                {
                    Id = Guid.NewGuid(),
                    Brand = "Tesla",
                    Model = "Model S",
                    LicensePlate = "DD 22 222"
                }
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
            var toRemoveVehicle = new VehicleDTO
            {
                Id = Guid.NewGuid(),
                Brand = "Lucid",
                Model = "Air",
                LicensePlate = "AA 69 420"
            };

            // Act
            var result = _vehicleRepository.Remove(toRemoveVehicle);

            // Assert
            Assert.False(result.Succeeded);
        }

        private void AssertAllVehicleProperties(IVehicle exptectedVehicle, IVehicle actualVehicle)
        {
            Assert.Equal(exptectedVehicle.Id, actualVehicle.Id);
            Assert.Equal(exptectedVehicle.Brand, actualVehicle.Brand);
            Assert.Equal(exptectedVehicle.Model, actualVehicle.Model);
            Assert.Equal(exptectedVehicle.LicensePlate, actualVehicle.LicensePlate);
            Assert.Equal(exptectedVehicle.CustomerId, actualVehicle.CustomerId);
        }
    }
}
