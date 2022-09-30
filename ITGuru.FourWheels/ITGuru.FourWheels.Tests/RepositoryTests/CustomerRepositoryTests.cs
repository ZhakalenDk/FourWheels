using ITGuru.FourWheels.Data;
using ITGuru.FourWheels.Service;

namespace ITGuru.FourWheels.Tests.RepositoryTests
{
    public class CustomerRepositoryTests : IDisposable
    {
//#pragma warning disable IDE1006 // Naming Styles - It doesn't make sense to use Pascal, as the member is more visible in upper case.
//        private static readonly ICustomer _DEFAULT_CUSTOMER = new CustomerDTO
//        {
//            Id = Guid.NewGuid(),
//            FirstName = "Test",
//            LastName = "Customer",
//            Phone = "12345678",
//            Email = "test@itguru.com"
//        };
//#pragma warning restore IDE1006 // Naming Styles

        private ICustomerService _customerRepository;
        private IVehicleService _vehicleRepository;

        public CustomerRepositoryTests()
        {
            DataLayer.WipeData();

            _customerRepository = new CustomerService();
            _vehicleRepository = new VehicleService();
        }

        public void Dispose()
        {
            DataLayer.WipeData();
        }

        [Fact]
        public void AddAndGetCustomerTest()
        {
            // Arrange
            ICustomer toAddCustomer = new CustomerDTO
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "Customer",
                Phone = "12345678",
                Email = "test@itguru.com"
            };

            // Act
            // Save customer in repository.
            var addResult = _customerRepository.Add(toAddCustomer);

            // Retrieve the newly added customer from the repository.
            var addedCustomer = _customerRepository.GetById(toAddCustomer.Id);

            // Assert
            Assert.True(addResult.Succeeded);
            Assert.NotNull(addedCustomer);
            AssertMulti.AllCustomerProperties(toAddCustomer, addedCustomer);
        }

        [Fact]
        public void AddAndRemoveCustomerTest()
        {
            // 1. Add
            // Arrange
            ICustomer toAddCustomer = new CustomerDTO
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "Customer",
                Phone = "12345678",
                Email = "test@itguru.com"
            };

            // Act
            var addResult = _customerRepository.Add(toAddCustomer);
            var addedCustomer = _customerRepository.GetById(toAddCustomer.Id);

            // Assert
            Assert.True(addResult.Succeeded);
            Assert.NotNull(addedCustomer);
            AssertMulti.AllCustomerProperties(toAddCustomer, addedCustomer);

            // 2. Delete
            // Act
            var removeResult = _customerRepository.Remove(addedCustomer);
            var removedCustomer = _customerRepository.GetById(addedCustomer.Id);

            // Assert
            Assert.True(removeResult.Succeeded);
            Assert.Null(removedCustomer);
        }

        [Fact]
        public void AddAndUpdateCustomerTest()
        {
            // 1. Add
            // Arrange
            var customerIdentity = Guid.NewGuid();
            var toAddCustomer = new CustomerDTO
            {
                Id = customerIdentity,
                FirstName = "Addd",
                LastName = "cu$t oMer",
                Phone = "99999999",
                Email = "test@itguru.com"
            };
            var afterEditCustomer = new CustomerDTO
            {
                Id = customerIdentity,
                FirstName = "Edited",
                LastName = "Customer",
                Phone = "11111111",
                Email = "test@itguru.dk"
            };

            // Act
            var addResult = _customerRepository.Add(toAddCustomer);
            var addedCustomer = _customerRepository.GetById(toAddCustomer.Id);

            // Assert
            Assert.True(addResult.Succeeded);
            Assert.NotNull(addedCustomer);
            AssertMulti.AllCustomerProperties(toAddCustomer, addedCustomer);

            // 2. Update
            // Act
            var updateResult = _customerRepository.Update(afterEditCustomer); // TODO: Customer hasn't even been added when inspecting the data layer???
            var editedCustomer = _customerRepository.GetById(addedCustomer.Id);

            // Assert
            Assert.True(updateResult.Succeeded);
            Assert.NotNull(editedCustomer);
            AssertMulti.AllCustomerProperties(afterEditCustomer, editedCustomer);
        }

        [Fact]
        public void AddDublicateCustomerTest()
        {
            // Arrange
            var toAddCustomer = new CustomerDTO
            {
                Id = Guid.NewGuid(),
                FirstName = "Addd",
                LastName = "cu$t oMer",
                Phone = "99999999",
                Email = "test@itguru.com"
            };

            // Act
            _customerRepository.Add(toAddCustomer);
            _customerRepository.Add(toAddCustomer);
            _customerRepository.Add(toAddCustomer);

            var allCustomers = _customerRepository.GetAll();

            // Assert
            var returnedCustomers = allCustomers.Where(c => c.Id == toAddCustomer.Id);
            Assert.NotNull(returnedCustomers.FirstOrDefault());
            AssertMulti.AllCustomerProperties(toAddCustomer, returnedCustomers.First());
            Assert.Single(returnedCustomers);
        }

        [Fact]
        public void GetAllCustomers()
        {
            // Arrange
            var toAddCustomers = new List<CustomerDTO>()
            {
                new CustomerDTO
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Customer",
                    LastName = "One",
                    Phone = "11111111",
                    Email = "test1@itguru.com"
                },
                new CustomerDTO
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Customer",
                    LastName = "Two",
                    Phone = "22222222",
                    Email = "test2@itguru.com"
                },
                new CustomerDTO
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Customer",
                    LastName = "Three",
                    Phone = "33333333",
                    Email = "test3@itguru.com"
                }
            };

            bool addAllSuccess = true;
            foreach (var customer in toAddCustomers)
            {
                addAllSuccess = _customerRepository.Add(customer).Succeeded && addAllSuccess;
            }

            // Act
            var retrievedCustomers = _customerRepository.GetAll();

            // Assert
            Assert.True(addAllSuccess);

            foreach (var customer in toAddCustomers)
            {
                // Assert: Customer is present and data is correct.
                var retrievedCustomer = retrievedCustomers.Where(c => c.Id == customer.Id).FirstOrDefault();
                Assert.NotNull(retrievedCustomer);
                AssertMulti.AllCustomerProperties(customer, retrievedCustomer);

                // Assert: Customer is present once only.
                Assert.Single(retrievedCustomers.Where(c => c.Id == customer.Id));
            }
        }

        [Fact]
        public void DeleteNonExistingCustomerTest()
        {
            // Arrange
            ICustomer nonExistingCustomer = new CustomerDTO
            {
                Id = Guid.NewGuid()
            };

            // Act
            var result = _customerRepository.Remove(nonExistingCustomer);

            // Assert
            Assert.False(result.Succeeded);
        }

        //[Fact]
        //public void GetVehiclesThroughCustomerTest()
        //{
        //    Guid _DEFAULT_VEHICLE_ID = Guid.NewGuid();

        //    ICustomer _DEFAULT_CUSTOMER = new CustomerDTO
        //    {
        //        Id = Guid.NewGuid(),
        //        FirstName = "Customer",
        //        LastName = "0",
        //        Phone = "00000000",
        //        Email = "test@itguru.com"
        //    };
        //    ICustomer _DEFAULT_CUSTOMER_1 = new CustomerDTO
        //    {
        //        Id = Guid.NewGuid(),
        //        FirstName = "Customer",
        //        LastName = "1",
        //        Phone = "11111111",
        //        Email = "test@itguru.com"
        //    };

        //    IVehicle _DEFAULT_VEHICLE = new VehicleDTO
        //    {
        //        Id = _DEFAULT_VEHICLE_ID,
        //        Brand = "Lucid",
        //        Model = "Air",
        //        LicensePlate = "AA 69 420",
        //        CustomerId = _DEFAULT_CUSTOMER.Id
        //    };
        //    IVehicle _DEFAULT_VEHICLE_EDITED = new VehicleDTO
        //    {
        //        Id = _DEFAULT_VEHICLE_ID,
        //        Brand = "Tesla",
        //        Model = "Model Y",
        //        LicensePlate = "BB 96 024",
        //        CustomerId = _DEFAULT_CUSTOMER_1.Id
        //    };
        //    IVehicle _DEFAULT_VEHICLE_1 = new VehicleDTO
        //    {
        //        Id = Guid.NewGuid(),
        //        Brand = "Volkswagen",
        //        Model = "ID.3",
        //        LicensePlate = "CC 12 345",
        //        CustomerId = _DEFAULT_CUSTOMER.Id
        //    };
        //    IVehicle _DEFAULT_VEHICLE_2 = new VehicleDTO
        //    {
        //        Id = Guid.NewGuid(),
        //        Brand = "Tesla",
        //        Model = "Model S",
        //        LicensePlate = "DD 22 222",
        //        CustomerId = _DEFAULT_CUSTOMER_1.Id
        //    };

        //    List<IVehicle> _VEHICLES = new()
        //    {
        //        _DEFAULT_VEHICLE,
        //        _DEFAULT_VEHICLE_1,
        //        _DEFAULT_VEHICLE_2
        //    };

        //    // Arrange
        //    var customer0Vehicles = _VEHICLES.Where(v => v.CustomerId == _DEFAULT_CUSTOMER.Id);
        //    var customer1Vehicles = _VEHICLES.Where(v => v.CustomerId == _DEFAULT_CUSTOMER_1.Id);

        //    var customerAddResult = true;
        //    customerAddResult = _customerRepository.Add(_DEFAULT_CUSTOMER).Succeeded && customerAddResult;
        //    customerAddResult = _customerRepository.Add(_DEFAULT_CUSTOMER_1).Succeeded && customerAddResult;

        //    var vehicleAddResult = true;
        //    foreach (var vehicle in customer0Vehicles)
        //    {
        //        vehicleAddResult = _vehicleRepository.Add(vehicle).Succeeded && vehicleAddResult;
        //    }

        //    foreach (var vehicle in customer1Vehicles)
        //    {
        //        vehicleAddResult = _vehicleRepository.Add(vehicle).Succeeded && vehicleAddResult;
        //    }

        //    var customer0 = _customerRepository.GetById(_DEFAULT_CUSTOMER.Id);
        //    var customer1 = _customerRepository.GetById(_DEFAULT_CUSTOMER_1.Id);

        //    //var test = DataLayer.Data.GetAllCustomers();

        //    // Act
        //    var retrievedCustomer0Vehicles = customer0.GetVehicles();
        //    var retrievedCustomer1Vehicles = customer1.GetVehicles();

        //    // Assert
        //    Assert.True(customerAddResult);
        //    Assert.True(vehicleAddResult);

        //    Assert.NotNull(retrievedCustomer0Vehicles);
        //    Assert.NotNull(retrievedCustomer1Vehicles);
        //    Assert.NotEmpty(retrievedCustomer0Vehicles);
        //    Assert.NotEmpty(retrievedCustomer1Vehicles);

        //    foreach (var actualVehicle in retrievedCustomer0Vehicles)
        //    {
        //        var expectedVehicle = customer0Vehicles.Where(v => v.Id == actualVehicle.Id).FirstOrDefault();
        //        Assert.NotNull(expectedVehicle);
        //        AssertAllVehicleProperties(expectedVehicle, actualVehicle);
        //    }

        //    foreach (var actualVehicle in retrievedCustomer1Vehicles)
        //    {
        //        var expectedVehicle = customer1Vehicles.Where(v => v.Id == actualVehicle.Id).FirstOrDefault();
        //        Assert.NotNull(expectedVehicle);
        //        AssertAllVehicleProperties(expectedVehicle, actualVehicle);
        //    }
        //}
    }
}
