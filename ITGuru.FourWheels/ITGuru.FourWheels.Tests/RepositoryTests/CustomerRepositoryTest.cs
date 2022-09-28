using ITGuru.FourWheels.Data.Interfaces;
using ITGuru.FourWheels.Data;
using ITGuru.FourWheels.Service;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace ITGuru.FourWheels.Tests.RepositoryTests
{
    public class CustomerRepositoryTests
    {
        private readonly ICustomer _DEFAULT_CUSTOMER = new CustomerDTO {
            Id = Guid.NewGuid(),
            FirstName = "Test",
            LastName = "Customer",
            Phone = "12345678",
            Email = "test@itguru.com"
        };

        [Fact]
        public void CreateAndGetCustomerTest()
        {
            // Arrange
            var customerRepository = GetCustomerRepository();

            // Act
            // Save customer in repository.
            var addResult = customerRepository.Add(_DEFAULT_CUSTOMER);

            // Retrieve the newly created customer from the repository.
            var createdCustomer = customerRepository.GetById(_DEFAULT_CUSTOMER.Id);

            // Assert
            Assert.True(addResult.Succeeded);
            Assert.NotNull(createdCustomer);
            Assert.Equal(createdCustomer.Id, createdCustomer.Id);
            Assert.Equal(createdCustomer.FirstName, createdCustomer.FirstName);
            Assert.Equal(createdCustomer.LastName, createdCustomer.LastName);
            Assert.Equal(createdCustomer.Phone, createdCustomer.Phone);
            Assert.Equal(createdCustomer.Email, createdCustomer.Email);
        }

        [Fact]
        public void CreateAndDeleteCustomerTest()
        {
            // 1. Create
            // Arrange
            var customerRepository = GetCustomerRepository();

            // Act
            var addResult = customerRepository.Add(_DEFAULT_CUSTOMER);
            var createdCustomer = customerRepository.GetById(_DEFAULT_CUSTOMER.Id);

            // Assert
            Assert.True(addResult.Succeeded);
            Assert.NotNull(createdCustomer);
            Assert.Equal(_DEFAULT_CUSTOMER.Id, createdCustomer.Id);
            Assert.Equal(_DEFAULT_CUSTOMER.FirstName, createdCustomer.FirstName);
            Assert.Equal(_DEFAULT_CUSTOMER.LastName, createdCustomer.LastName);
            Assert.Equal(_DEFAULT_CUSTOMER.Phone, createdCustomer.Phone);
            Assert.Equal(_DEFAULT_CUSTOMER.Email, createdCustomer.Email);

            // 2. Delete
            // Act
            var removeResult = customerRepository.Remove(createdCustomer);
            var deletedCustomer = customerRepository.GetById(createdCustomer.Id);

            // Assert
            Assert.True(removeResult.Succeeded);
            Assert.Null(deletedCustomer);
        }

        [Fact]
        public void CreateAndUpdateCustomerTest()
        {
            // 1. Create
            // Arrange
            var customerRepository = GetCustomerRepository();

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
            var addResult = customerRepository.Add(createCustomer);
            var createdCustomer = customerRepository.GetById(createCustomer.Id);

            // Assert
            Assert.True(addResult.Succeeded);
            Assert.NotNull(createdCustomer);
            Assert.Equal(createCustomer.Id, createdCustomer.Id);
            Assert.Equal(createCustomer.FirstName, createdCustomer.FirstName);
            Assert.Equal(createCustomer.LastName, createdCustomer.LastName);
            Assert.Equal(createCustomer.Phone, createdCustomer.Phone);
            Assert.Equal(createCustomer.Email, createdCustomer.Email);

            // 2. Update
            // Act
            var updateResult = customerRepository.Update(editCustomer);
            var editedCustomer = customerRepository.GetById(createdCustomer.Id);

            // Assert
            Assert.True(updateResult.Succeeded);
            Assert.NotNull(editedCustomer);
            Assert.Equal(editCustomer.Id, editedCustomer.Id);
            Assert.Equal(editCustomer.FirstName, editedCustomer.FirstName);
            Assert.Equal(editCustomer.LastName, editedCustomer.LastName);
            Assert.Equal(editCustomer.Phone, editedCustomer.Phone);
            Assert.Equal(editCustomer.Email, editedCustomer.Email);
        }

        [Fact]
        public void GetAllCustomers()
        {
            // 1. Create
            // Arrange
            var customerRepository = GetCustomerRepository();

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
                addAllSuccess = customerRepository.Add(customer).Succeeded && addAllSuccess;
            }

            // Act
            var retrievedCustomers = customerRepository.GetAll();

            // Assert
            Assert.True(addAllSuccess);

            foreach (var customer in customersToCreate)
            {
                // Assert: Customer is present and data is correct.
                var retrievedCustomer = retrievedCustomers.Where(c => c.Id == customer.Id).FirstOrDefault();
                Assert.NotNull(retrievedCustomer);
                Assert.Equal(customer.Id, retrievedCustomer.Id);
                Assert.Equal(customer.FirstName, retrievedCustomer.FirstName);
                Assert.Equal(customer.LastName, retrievedCustomer.LastName);
                Assert.Equal(customer.Phone, retrievedCustomer.Phone);
                Assert.Equal(customer.Email, retrievedCustomer.Email);

                // Assert: Customer is present once only.
                Assert.Equal(1, retrievedCustomers.Where(c => c.Id == customer.Id).Count());
            }
        }

        [Fact]
        public void AddDublicateCustomerTest()
        {
            // Arrange
            var customerRepository = GetCustomerRepository();

            // Act
            customerRepository.Add(_DEFAULT_CUSTOMER);
            customerRepository.Add(_DEFAULT_CUSTOMER);
            customerRepository.Add(_DEFAULT_CUSTOMER);

            var allCustomers = customerRepository.GetAll();

            // Assert
            var customersWithId = allCustomers.Where(c => c.Id == _DEFAULT_CUSTOMER.Id).FirstOrDefault();
            Assert.NotNull(customersWithId);
            Assert.Equal(1, allCustomers.Where(c => c.Id == _DEFAULT_CUSTOMER.Id).Count());
        }

        [Fact]
        public void DeleteNonExistingCustomerTest()
        {
            // Arrange
            var customerRepository = GetCustomerRepository();

            // Act
            var result = customerRepository.Remove(_DEFAULT_CUSTOMER);

            // Assert
            Assert.False(result.Succeeded);
        }

        private CustomerService GetCustomerRepository()
        {
            // Simple class instance
            IDataLayer data = new ITGuru.FourWheels.Data.DataLayer();
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
