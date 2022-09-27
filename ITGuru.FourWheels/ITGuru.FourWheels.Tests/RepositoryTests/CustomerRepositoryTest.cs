using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace ITGuru.FourWheels.Tests.RepositoryTests
{
    public class UnitTest1
    {
        [Fact]
        public void CreateAndGetCustomerTest()
        {
            // Arrange
            var customerRepository = GetCustomerRepository();

            var customerToCreate = new CreateCustomerDTO
            {
                Id = new Guid(),
                FirstName = "Test",
                LastName = "Customer",
                Phone = "12345678",
                EmailAddress = "test@itguru.com"
            };

            // Act
            // Save customer in repository.
            customerRepository.CreateCustomer(customerToCreate);

            // Retrieve the newly created customer from the repository.
            var createdCustomer = customerRepository.GetCustomerById(customerToCreate.Id);

            // Assert
            Assert.NotNull(createdCustomer);
            Assert.Equal(createdCustomer.Id, createdCustomer.Id);
            Assert.Equal(createdCustomer.FirstName, createdCustomer.FirstName);
            Assert.Equal(createdCustomer.LastName, createdCustomer.LastName);
            Assert.Equal(createdCustomer.Phone, createdCustomer.Phone);
            Assert.Equal(createdCustomer.EmailAddress, createdCustomer.EmailAddress);
        }

        [Fact]
        public void CreateAndDeleteCustomerTest()
        {
            // 1. Create
            // Arrange
            var customerRepository = GetCustomerRepository();

            var customerToCreate = new CreateCustomerDTO
            {
                Id = new Guid(),
                FirstName = "Test",
                LastName = "Customer",
                Phone = "12345678",
                EmailAddress = "test@itguru.com"
            };

            // Act
            customerRepository.CreateCustomer(customerToCreate);
            var createdCustomer = customerRepository.GetCustomer(customerToCreate.Id);

            // Assert
            Assert.NotNull(createdCustomer);
            Assert.Equal(customerToCreate.Id, createdCustomer.Id);
            Assert.Equal(customerToCreate.FirstName, createdCustomer.FirstName);
            Assert.Equal(customerToCreate.LastName, createdCustomer.LastName);
            Assert.Equal(customerToCreate.Phone, createdCustomer.Phone);
            Assert.Equal(customerToCreate.EmailAddress, createdCustomer.EmailAddress);

            // 2. Delete
            // Act
            customerRepository.DeleteCustomer(createdCustomer.Id);
            var deletedCustomer = customerRepository.GetCustomer(createdCustomer.Id);

            // Assert
            Assert.Null(deletedCustomer);
        }

        [Fact]
        public void CreateAndUpdateCustomerTest()
        {
            // 1. Create
            // Arrange
            var customerRepository = GetCustomerRepository();

            var customerIdentity = new Guid();
            var createCustomer = new CreateCustomerDTO
            {
                Id = customerIdentity,
                FirstName = "Created",
                LastName = "cu$t oMer",
                Phone = "99999999",
                EmailAddress = "test@itguru.com"
            };
            var editCustomer = new EditCustomerDTO
            {
                Id = customerIdentity,
                FirstName = "Edited",
                LastName = "Customer",
                Phone = "11111111",
                EmailAddress = "test@itguru.dk"
            };

            // Act
            customerRepository.CreateCustomer(createCustomer);
            var createdCustomer = customerRepository.GetCustomer(createCustomer.Id);

            // Assert
            Assert.NotNull(createdCustomer);
            Assert.Equal(createCustomer.Id, createdCustomer.Id);
            Assert.Equal(createCustomer.FirstName, createdCustomer.FirstName);
            Assert.Equal(createCustomer.LastName, createdCustomer.LastName);
            Assert.Equal(createCustomer.Phone, createdCustomer.Phone);
            Assert.Equal(createCustomer.EmailAddress, createdCustomer.EmailAddress);

            // 2. Update
            // Act
            customerRepository.UpdateCustomer(editCustomer);
            var editedCustomer = customerRepository.GetCustomer(createdCustomer.Id);

            // Assert
            Assert.NotNull(editedCustomer);
            Assert.Equal(editCustomer.Id, editedCustomer.Id);
            Assert.Equal(editCustomer.FirstName, editedCustomer.FirstName);
            Assert.Equal(editCustomer.LastName, editedCustomer.LastName);
            Assert.Equal(editCustomer.Phone, editedCustomer.Phone);
            Assert.Equal(editCustomer.EmailAddress, editedCustomer.EmailAddress);
        }

        [Fact]
        public void GetAllCustomers()
        {
            // 1. Create
            // Arrange
            var customerRepository = GetCustomerRepository();

            var customersToCreate = new List<CreateCustomerDTO>()
            {
                new CreateCustomerDTO
                {
                    Id = new Guid(),
                    FirstName = "Customer",
                    LastName = "One",
                    Phone = "11111111",
                    EmailAddress = "test1@itguru.com"
                },
                new CreateCustomerDTO
                {
                    Id = new Guid(),
                    FirstName = "Customer",
                    LastName = "Two",
                    Phone = "22222222",
                    EmailAddress = "test2@itguru.com"
                },
                new CreateCustomerDTO
                {
                    Id = new Guid(),
                    FirstName = "Customer",
                    LastName = "Three",
                    Phone = "33333333",
                    EmailAddress = "test3@itguru.com"
                }
            };

            foreach (var customer in customersToCreate)
            {
                customerRepository.CreateCustomer(customer);
            }

            // Act
            var allCustomers = customerRepository.GetAllCustomers();

            // Assert
            foreach (var customer in customersToCreate)
            {
                // Assert: Customer is present and data is correct.
                var createdCustomer = allCustomers.Where(c => c.Id == customer.Id).FirstOrDefault();
                Assert.NotNull(createdCustomer);
                Assert.Equal(createdCustomer.Id, customer.Id);
                Assert.Equal(createdCustomer.FirstName, customer.FirstName);
                Assert.Equal(createdCustomer.LastName, customer.LastName);
                Assert.Equal(createdCustomer.Phone, customer.Phone);
                Assert.Equal(createdCustomer.EmailAddress, customer.EmailAddress);

                // Assert: Customer is present once only.
                Assert.Equal(1, allCustomers.Where(c => c.Id == customer.Id).Count());
            }
        }

        private CustomerRepository GetCustomerRepository()
        {
            // Simple class
            return new CustomerRepository();

            // EF Core


            // API
            //await using var application = new WebApplicationFactory<Program>();
            //using var client = application.CreateClient();
            //client.BaseAddress = new Uri(_BASE_URI_STR);
            // Then use client to POST, GET etc.
        }
    }
}
