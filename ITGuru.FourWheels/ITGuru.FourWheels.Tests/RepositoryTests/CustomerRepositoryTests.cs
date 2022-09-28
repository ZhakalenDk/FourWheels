using ITGuru.FourWheels.DataLayer;
using ITGuru.FourWheels.Service;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.ComponentModel.DataAnnotations;
using System.Xml;
using ITGuru.FourWheels.DataLayer.DataModels;

namespace ITGuru.FourWheels.Tests.RepositoryTests
{
    public class CustomerRepositoryTests
    {
        private readonly ICustomer _DEFAULT_CUSTOMER = new CustomerDTO
        {
            Id = Guid.NewGuid(),
            FirstName = "Test",
            LastName = "Customer",
            Phone = "12345678",
            Email = "test@itguru.com"
        };

        private CustomerService _customerRepository;

        public CustomerRepositoryTests()
        {
            _customerRepository = GetCustomerRepository();
        }

        [Fact]
        public void CreateAndGetCustomerTest()
        {
            // Arrange

            // Act
            // Save customer in repository.
            var addResult = _customerRepository.Add(_DEFAULT_CUSTOMER);

            // Retrieve the newly created customer from the repository.
            var createdCustomer = _customerRepository.GetById(_DEFAULT_CUSTOMER.Id);

            // Assert
            Assert.True(addResult.Succeeded);
            Assert.NotNull(createdCustomer);
            AssertAllCustomerProperties(_DEFAULT_CUSTOMER, createdCustomer);
        }

        [Fact]
        public void CreateAndDeleteCustomerTest()
        {
            // 1. Create
            // Arrange

            // Act
            var addResult = _customerRepository.Add(_DEFAULT_CUSTOMER);
            var createdCustomer = _customerRepository.GetById(_DEFAULT_CUSTOMER.Id);

            // Assert
            Assert.True(addResult.Succeeded);
            Assert.NotNull(createdCustomer);
            AssertAllCustomerProperties(_DEFAULT_CUSTOMER, createdCustomer);

            // 2. Delete
            // Act
            var removeResult = _customerRepository.Remove(createdCustomer);
            var deletedCustomer = _customerRepository.GetById(createdCustomer.Id);

            // Assert
            Assert.True(removeResult.Succeeded);
            Assert.Null(deletedCustomer);
        }

        [Fact]
        public void CreateAndUpdateCustomerTest()
        {
            // 1. Create
            // Arrange
            var customerIdentity = Guid.NewGuid();
            var createCustomer = new CustomerDTO
            {
                Id = customerIdentity,
                FirstName = "Created",
                LastName = "cu$t oMer",
                Phone = "99999999",
                Email = "test@itguru.com"
            };
            var editCustomer = new CustomerDTO
            {
                Id = customerIdentity,
                FirstName = "Edited",
                LastName = "Customer",
                Phone = "11111111",
                Email = "test@itguru.dk"
            };

            // Act
            var addResult = _customerRepository.Add(createCustomer);
            var createdCustomer = _customerRepository.GetById(createCustomer.Id);

            // Assert
            Assert.True(addResult.Succeeded);
            Assert.NotNull(createdCustomer);
            AssertAllCustomerProperties(createCustomer, createdCustomer);

            // 2. Update
            // Act
            var updateResult = _customerRepository.Update(editCustomer);
            var editedCustomer = _customerRepository.GetById(createdCustomer.Id);

            // Assert
            Assert.True(updateResult.Succeeded);
            Assert.NotNull(editedCustomer);
            AssertAllCustomerProperties(editCustomer, editedCustomer);
        }

        [Fact]
        public void AddDublicateCustomerTest()
        {
            // Arrange

            // Act
            _customerRepository.Add(_DEFAULT_CUSTOMER);
            _customerRepository.Add(_DEFAULT_CUSTOMER);
            _customerRepository.Add(_DEFAULT_CUSTOMER);

            var allCustomers = _customerRepository.GetAll();

            // Assert
            var returnedCustomers = allCustomers.Where(c => c.Id == _DEFAULT_CUSTOMER.Id);
            Assert.NotNull(returnedCustomers.FirstOrDefault());
            Assert.Single(returnedCustomers);
        }

        [Fact]
        public void GetAllCustomers()
        {
            // Arrange
            var customersToCreate = new List<CustomerDTO>()
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
            foreach (var customer in customersToCreate)
            {
                addAllSuccess = _customerRepository.Add(customer).Succeeded && addAllSuccess;
            }

            // Act
            var retrievedCustomers = _customerRepository.GetAll();

            // Assert
            Assert.True(addAllSuccess);

            foreach (var customer in customersToCreate)
            {
                // Assert: Customer is present and data is correct.
                var retrievedCustomer = retrievedCustomers.Where(c => c.Id == customer.Id).FirstOrDefault();
                Assert.NotNull(retrievedCustomer);
                AssertAllCustomerProperties(customer, retrievedCustomer);

                // Assert: Customer is present once only.
                Assert.Single(retrievedCustomers.Where(c => c.Id == customer.Id));
            }
        }

        [Fact]
        public void DeleteNonExistingCustomerTest()
        {
            // Arrange

            // Act
            var result = _customerRepository.Remove(_DEFAULT_CUSTOMER);

            // Assert
            Assert.False(result.Succeeded);
        }

        private void AssertAllCustomerProperties(ICustomer exptectedCustomer, ICustomer actualCustomer)
        {
            Assert.Equal(exptectedCustomer.Id, actualCustomer.Id);
            Assert.Equal(exptectedCustomer.FirstName, actualCustomer.FirstName);
            Assert.Equal(exptectedCustomer.LastName, actualCustomer.LastName);
            Assert.Equal(exptectedCustomer.Phone, actualCustomer.Phone);
            Assert.Equal(exptectedCustomer.Email, actualCustomer.Email);
        }

        private CustomerService GetCustomerRepository()
        {
            // Simple class instance
            IDataLayer data = new ITGuru.FourWheels.DataLayer.DataLayer();
            return new CustomerService(data);

            // EF Core


            // API
            //await using var application = new WebApplicationFactory<Program>();
            //using var client = application.CreateClient();
            //client.BaseAddress = new Uri(_BASE_URI_STR);
            // Then use client to POST, GET etc.
        }
    }
}
