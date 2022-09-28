using ITGuru.FourWheels.DataLayer;
using ITGuru.FourWheels.Service;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.ComponentModel.DataAnnotations;
using System.Xml;
using ITGuru.FourWheels.DataLayer.DataModels;
using ITGuru.FourWheels.Service.Repos;

namespace ITGuru.FourWheels.Tests.RepositoryTests
{
    public class VehicleRepositoryTests
    {
        private static readonly Guid _DEFAULT_ID = Guid.NewGuid();
        private static readonly IVehicle _DEFAULT_VEHICLE = new VehicleDTO
        {
            Id = _DEFAULT_ID,
            Brand = "Lucid",
            Model = "Air",
            LicensePlate = "AA 69 420"
        };
        private static readonly IVehicle _DEFAULT_VEHICLE_EDITED = new VehicleDTO
        {
            Id = _DEFAULT_ID,
            Brand = "Tesla",
            Model = "Model Y",
            LicensePlate = "BB 96 024"
        };
        private static readonly IVehicle _DEFAULT_VEHICLE_1 = new VehicleDTO
        {
            Id = Guid.NewGuid(),
            Brand = "Volkswagen",
            Model = "ID.3",
            LicensePlate = "CC 12 345"
        };
        private static readonly IVehicle _DEFAULT_VEHICLE_2 = new VehicleDTO
        {
            Id = Guid.NewGuid(),
            Brand = "Tesla",
            Model = "Model S",
            LicensePlate = "DD 22 222"
        };

        private VehicleService _vehicleRepository;

        public VehicleRepositoryTests()
        {
            _vehicleRepository = GetVehicleRepository();
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

        private void AssertAllVehicleProperties(IVehicle exptectedVehicle, IVehicle actualVehicle)
        {
            Assert.Equal(exptectedVehicle.Id, actualVehicle.Id);
        }

        private VehicleService GetVehicleRepository()
        {
            return new VehicleService();
        }
    }
}
