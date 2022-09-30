using ITGuru.FourWheels.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITGuru.FourWheels.Tests
{
    internal static class TestData
    {
        // IDs
        private static readonly Guid DEFAULT_CUSTOMER_ID = Guid.NewGuid();
        private static readonly Guid DEFAULT_VEHICLE_ID = Guid.NewGuid();
        private static readonly Guid DEFAULT_TASK_ID = Guid.NewGuid();

#pragma warning disable IDE1006 // Naming Styles - It doesn't make sense to use Pascal, as the member is more visible in upper case.
        // Customers
        public static readonly ICustomer DEFAULT_CUSTOMER = new CustomerDTO
        {
            Id = DEFAULT_CUSTOMER_ID,
            FirstName = "Customer",
            LastName = "0",
            Phone = "00000000",
            Email = "test@itguru.com"
        };
        public static readonly ICustomer DEFAULT_CUSTOMER_EDITED = new CustomerDTO
        {
            Id = DEFAULT_CUSTOMER_ID,
            FirstName = "Edddito",
            LastName = "cu$t oMO",
            Phone = "69696969",
            Email = "yo@itgangster.com"
        };
        public static readonly ICustomer DEFAULT_CUSTOMER_1 = new CustomerDTO
        {
            Id = Guid.NewGuid(),
            FirstName = "Customer",
            LastName = "1",
            Phone = "11111111",
            Email = "test1@itguru.com"
        };
        public static readonly ICustomer DEFAULT_CUSTOMER_2 = new CustomerDTO
        {
            Id = Guid.NewGuid(),
            FirstName = "Customer",
            LastName = "2",
            Phone = "22222222",
            Email = "test2@itguru.com"
        };

        // Vehicles
        public static readonly IVehicle DEFAULT_VEHICLE = new VehicleDTO
        {
            Id = DEFAULT_VEHICLE_ID,
            Brand = "Lucid",
            Model = "Air",
            LicensePlate = "AA 69 420",
            CustomerId = DEFAULT_CUSTOMER.Id
        };
        public static readonly IVehicle DEFAULT_VEHICLE_EDITED = new VehicleDTO
        {
            Id = DEFAULT_VEHICLE_ID,
            Brand = "Tesla",
            Model = "Model Y",
            LicensePlate = "BB 96 024",
            CustomerId = DEFAULT_CUSTOMER_1.Id
        };
        public static readonly IVehicle DEFAULT_VEHICLE_1 = new VehicleDTO
        {
            Id = Guid.NewGuid(),
            Brand = "Volkswagen",
            Model = "ID.3",
            LicensePlate = "CC 12 345",
            CustomerId = DEFAULT_CUSTOMER.Id
        };
        public static readonly IVehicle DEFAULT_VEHICLE_2 = new VehicleDTO
        {
            Id = Guid.NewGuid(),
            Brand = "Tesla",
            Model = "Model S",
            LicensePlate = "DD 22 222",
            CustomerId = DEFAULT_CUSTOMER_1.Id
        };

        // Tasks
        public static readonly ITask DEFAULT_TASK = new TaskDTO
        {
            Id = DEFAULT_TASK_ID,
            OrderNumber = "ORDER_NUM_0",
            OrderDate = new DateTime(1975, 1, 1),
            StartDate = new DateTime(1975, 1, 2),
            FinishDate = new DateTime(1975, 1, 3),
            AssociatedVehicleId = DEFAULT_VEHICLE.Id,
            Description = "Description 0",
            Notes = "Notes 0"
        };
        public static readonly ITask DEFAULT_TASK_EDITED = new TaskDTO
        {
            Id = DEFAULT_TASK_ID,
            OrderNumber = "ORDER_NUM_11",
            OrderDate = new DateTime(1975, 2, 4),
            StartDate = new DateTime(1975, 2, 5),
            FinishDate = new DateTime(1975, 2, 6),
            AssociatedVehicleId = DEFAULT_VEHICLE_1.Id,
            Description = "Edited Description 1",
            Notes = "Edited Notes 1"
        };
        public static readonly ITask DEFAULT_TASK_1 = new TaskDTO
        {
            Id = Guid.NewGuid(),
            OrderNumber = "ORDER_NUM_1",
            OrderDate = new DateTime(1976, 1, 1),
            StartDate = new DateTime(1976, 1, 2),
            FinishDate = new DateTime(1976, 1, 3),
            AssociatedVehicleId = DEFAULT_VEHICLE_1.Id,
            Description = "Description 1",
            Notes = "Notes 1"
        };
        public static readonly ITask DEFAULT_TASK_2 = new TaskDTO
        {
            Id = Guid.NewGuid(),
            OrderNumber = "ORDER_NUM_2",
            OrderDate = new DateTime(1977, 1, 1),
            StartDate = new DateTime(1977, 1, 2),
            FinishDate = new DateTime(1977, 1, 3),
            AssociatedVehicleId = DEFAULT_VEHICLE_2.Id,
            Description = "Description 2",
            Notes = "Notes 2"
        };

        // Collections
        public static readonly List<ICustomer> CUSTOMERS = new()
        {
            DEFAULT_CUSTOMER,
            DEFAULT_CUSTOMER_1,
            DEFAULT_CUSTOMER_2
        };
        public static readonly List<IVehicle> VEHICLES = new()
        {
            DEFAULT_VEHICLE,
            DEFAULT_VEHICLE_1,
            DEFAULT_VEHICLE_2
        };
        public static readonly List<ITask> TASKS = new()
        {
            DEFAULT_TASK,
            DEFAULT_TASK_1,
            DEFAULT_TASK_2
        };

        
#pragma warning restore IDE1006 // Naming Styles
    }
}
