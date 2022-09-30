using ITGuru.FourWheels.Data;
using ITGuru.FourWheels.Service;

namespace ITGuru.FourWheels.Tests.RepositoryTests
{
    public class VehicleRepositoryTests
    {
        private IVehicleService _vehicleRepository;

        public VehicleRepositoryTests()
        {
            DataLayer.WipeData();

            _vehicleRepository = new VehicleService();
        }

        [Fact]
        public void AddAndGetVehicleTest()
        {
            // Arrange

            // Act
            // Save vehicle in repository.
            var addResult = _vehicleRepository.Add(TestData.DEFAULT_VEHICLE);

            // Retrieve the newly created vehicle from the repository.
            var addedVehicle = _vehicleRepository.GetById(TestData.DEFAULT_VEHICLE.Id);

            // Assert
            Assert.True(addResult.Succeeded);
            Assert.NotNull(addedVehicle);
            AssertMulti.AllVehicleProperties(TestData.DEFAULT_VEHICLE, addedVehicle);
        }

        [Fact]
        public void AddAndRemoveVehicleTest()
        {
            // 1. Add
            // Arrange

            // Act
            var addResult = _vehicleRepository.Add(TestData.DEFAULT_VEHICLE);
            var addedVehicle = _vehicleRepository.GetById(TestData.DEFAULT_VEHICLE.Id);

            // Assert
            Assert.True(addResult.Succeeded);
            Assert.NotNull(addedVehicle);
            AssertMulti.AllVehicleProperties(TestData.DEFAULT_VEHICLE, addedVehicle);

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

            // Act
            var addResult = _vehicleRepository.Add(TestData.DEFAULT_VEHICLE);
            var createdVehicle = _vehicleRepository.GetById(TestData.DEFAULT_VEHICLE.Id);

            // Assert
            Assert.True(addResult.Succeeded);
            Assert.NotNull(createdVehicle);
            AssertMulti.AllVehicleProperties(TestData.DEFAULT_VEHICLE, createdVehicle);

            // 2. Update
            // Act
            var updateResult = _vehicleRepository.Update(TestData.DEFAULT_VEHICLE_EDITED);
            var editedVehicle = _vehicleRepository.GetById(createdVehicle.Id);

            // Assert
            Assert.True(updateResult.Succeeded);
            Assert.NotNull(editedVehicle);
            AssertMulti.AllVehicleProperties(TestData.DEFAULT_VEHICLE_EDITED, editedVehicle);
        }

        [Fact]
        public void AddDublicateVehicleTest()
        {
            // Arrange

            // Act
            _vehicleRepository.Add(TestData.DEFAULT_VEHICLE);
            _vehicleRepository.Add(TestData.DEFAULT_VEHICLE);
            _vehicleRepository.Add(TestData.DEFAULT_VEHICLE);

            var allVehicles = _vehicleRepository.GetAll();

            // Assert
            var returnedVehicles = allVehicles.Where(c => c.Id == TestData.DEFAULT_VEHICLE.Id);
            Assert.NotNull(returnedVehicles.FirstOrDefault());
            Assert.Single(returnedVehicles);
        }

        [Fact]
        public void GetAllVehicles()
        {
            // Arrange

            bool addAllSuccess = true;
            foreach (var vehicle in TestData.VEHICLES)
            {
                addAllSuccess = _vehicleRepository.Add(vehicle).Succeeded && addAllSuccess;
            }

            // Act
            var retrievedVehicles = _vehicleRepository.GetAll();

            // Assert
            Assert.True(addAllSuccess);

            foreach (var vehicle in TestData.VEHICLES)
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
            IVehicle nonExistingVehicle = new VehicleDTO
            {
                Id = Guid.NewGuid()
            };

            // Act
            var result = _vehicleRepository.Remove(nonExistingVehicle);

            // Assert
            Assert.False(result.Succeeded);
        }
    }
}
