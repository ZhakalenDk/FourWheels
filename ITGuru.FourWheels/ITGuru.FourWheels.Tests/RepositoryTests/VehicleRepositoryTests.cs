using ITGuru.FourWheels.Data;
using ITGuru.FourWheels.Service;

namespace ITGuru.FourWheels.Tests.RepositoryTests
{
    public class VehicleRepositoryTests : IDisposable
    {
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
            AssertMulti.AllVehicleProperties(toAddVehicle, addedVehicle);
        }

        [Fact]
        public void AddAndRemoveVehicleTest()
        {
            // 1. Add
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
            AssertMulti.AllVehicleProperties(toAddVehicle, addedVehicle);

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
            // 1. Add
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
            AssertMulti.AllVehicleProperties(toAddVehicle, createdVehicle);

            // 2. Update
            // Act
            var updateResult = _vehicleRepository.Update(toUpdateVehicle);
            var editedVehicle = _vehicleRepository.GetById(createdVehicle.Id);

            // Assert
            Assert.True(updateResult.Succeeded);
            Assert.NotNull(editedVehicle);
            AssertMulti.AllVehicleProperties(toUpdateVehicle, editedVehicle);
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
            var vehiclesToAdd = new List<IVehicle>()
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
            foreach (var vehicle in vehiclesToAdd)
            {
                addAllSuccess = _vehicleRepository.Add(vehicle).Succeeded && addAllSuccess;
            }

            // Act
            var retrievedVehicles = _vehicleRepository.GetAll();

            // Assert
            Assert.True(addAllSuccess);

            foreach (var vehicle in vehiclesToAdd)
            {
                // Assert: Vehicle is present and data is correct.
                var retrievedVehicle = retrievedVehicles.Where(c => c.Id == vehicle.Id).FirstOrDefault();
                Assert.NotNull(retrievedVehicle);
                AssertMulti.AllVehicleProperties(vehicle, retrievedVehicle);

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
    }
}
