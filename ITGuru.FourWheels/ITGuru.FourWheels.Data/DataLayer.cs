﻿using ITGuru.FourWheels.Data.DataModels;

namespace ITGuru.FourWheels.Data
{
    public class DataLayer : IDataLayer
    {
        private DataLayer()
        {
            GenerateList();
        }

        private static readonly Object _lockObject = new Object();

        public static IDataLayer Data
        {
            get
            {
                lock(_lockObject)
                {
                    _data ??= new DataLayer();
                }

                return _data;
            }
        }
        private static IDataLayer _data;

        private List<Customer> _customers = new();

        public List<Customer> Customers
        {
            get { return _customers; }
        }

        private List<Vehicle> _vehicles = new();

        public List<Vehicle> Vehicles
        {
            get { return _vehicles; }
        }

        public static void WipeData()
        {
            lock (_lockObject)
            {
                if (_data != null)
                {
                    _data = null;
                }
            }
        }

        public void GenerateVehicleList(Guid customerID, string brand, string model, string licensePlate)
        {
            Guid guid = Guid.NewGuid();
            Vehicle vehicle = new()
            {
                Id = guid,
                LicensePlate = licensePlate,
                Brand = brand,
                Model = model,
                CustomerId = customerID,
                IsDeleted = false
            };
            Vehicles.Add(vehicle);
        }
        public void GenerateList()
        {
            Guid g = Guid.NewGuid();
            Customer customer = new Customer()
            {
                Id = g,
                FirstName = "Jens",
                LastName = "Neergaard",
                Email = "jensneergaard@hotmail.com",
                Phone = "12345678"
            };
            GenerateVehicleList(g, "Rolls-Royce", "Rolls-Royce Spectre (electric)", "RR66449");
            Customers.Add(customer);

            Guid g2 = Guid.NewGuid();
            Customer customer2 = new Customer()
            {
                Id = g2,
                FirstName = "Mike",
                LastName = "Mortensen",
                Email = "MikeMortensen@hotmail.com",
                Phone = "23456789"
            };
            GenerateVehicleList(g2, "Volkswagen", "GOLF", "VW45697");
            GenerateVehicleList(g2, "Cadilac", "XT5", "CC12345");
            Customers.Add(customer2);

            Guid g3 = Guid.NewGuid();
            Customer customer3 = new Customer()
            {
                Id = g3,
                FirstName = "Lukas",
                LastName = "Pederson",
                Email = "LukasPederson@hotmail.com",
                Phone = "34567890"
            };
            GenerateVehicleList(g3, "BMW", "1 Series (F52)", "The Boss 2");
            GenerateVehicleList(g3, "BMW", "5 Series", "The Boss");
            Customers.Add(customer3);

            Guid g4 = Guid.NewGuid();
            Customer customer4 = new Customer()
            {
                Id = g4,
                FirstName = "Simon",
                LastName = "Andreassen",
                Email = "SimonAndreassen@hotmail.com",
                Phone = "23456789"
            };
            GenerateVehicleList(g4, "Cadilac", "XT6", "CC34598");
            GenerateVehicleList(g4, "Cadilac", "CT4", "CC23584");
            GenerateVehicleList(g4, "Cadilac", "ESCALADE ESV", "CC98765");
            Customers.Add(customer4);

            Guid g5 = Guid.NewGuid();
            Customer customer5 = new Customer()
            {
                Id = g5,
                FirstName = "Jasmin",
                LastName = "Nielsen",
                Email = "JasminNielsen@hotmail.com",
                Phone = "23456789"
            };
            Customers.Add(customer5);
        }

        public List<Customer> GetAllCustomers(bool includeDeleted = false)
        {
            List<Customer> CustomerList = Customers.Where(x => x.Deleted == includeDeleted).ToList();
            return CustomerList;
        }

        /// <summary>
        /// Add a single Customer to the list
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>True if customer is added and its NOT already in the list</returns>
        public bool AddCustomer(Customer customer)
        {
            int index = Customers.FindIndex(x => x.Id == customer.Id);
            if (index >= 0)
            {
                return false;
            }
            else
            {
                Customers.Add(customer);
                return true;
            }
        }
        /// <summary>
        /// Update a single customer
        /// </summary>
        /// <param name="changed_customer"></param>
        /// <returns>True if Customer is succesfully updated</returns>
        public bool UpdateCustomer(Customer changed_customer)
        {
            Customer customer = Customers.Where(x => x.Id == changed_customer.Id).FirstOrDefault();

            if (customer != null)
            {
                customer.FirstName = changed_customer.FirstName;
                customer.LastName = changed_customer.LastName;
                customer.Email = changed_customer.Email;
                customer.Phone = changed_customer.Phone;
                customer.Deleted = changed_customer.Deleted;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Remove a single customer
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns>True if Customer is PERMENENTLY removed</returns>
        public bool HardDeleteCustomer(Guid customerID)
        {
            int index = Customers.FindIndex(x => x.Id == customerID);
            if (index >= 0)
            {
                Customers.RemoveAt(index);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes a single customer
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns>True if customer is there and IsDeleted is set</returns>
        public bool SoftDeleteCustomer(Guid customerID)
        {
            Customer customer = Customers.Where(x => x.Id == customerID).FirstOrDefault();

            if (customer != null)
            {
                customer.Deleted = true;
                return true;
            }
            return false;
        }

        public List<Vehicle> GetAllVehicles(bool includeDeleted = false)
        {
            List<Vehicle> VehicleList = Vehicles.Where(x => x.IsDeleted == includeDeleted).ToList();
            return VehicleList;
        }

        /// <summary>
        /// Add a single Vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns>True if Vehicle is added and no Dublecate is added</returns>
        public bool AddVehicle(Vehicle vehicle)
        {
            int index = Vehicles.FindIndex(x => x.Id == vehicle.Id);
            if (index >= 0)
            {
                return false;
            }
            else
            {
                Vehicles.Add(vehicle);
                return true;
            }
        }

        /// <summary>
        /// Updates a single vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns>True if Vehicle is updated</returns>
        public bool UpdateVehicle(Vehicle _vehicle)
        {
            Vehicle vehicle = Vehicles.Where(x => x.Id == _vehicle.Id).FirstOrDefault();

            if (vehicle != null)
            {
                vehicle.LicensePlate = _vehicle.LicensePlate;
                vehicle.IsDeleted = _vehicle.IsDeleted;
                vehicle.Model = _vehicle.Model;
                vehicle.Brand = _vehicle.Brand;
                vehicle.CustomerId = _vehicle.CustomerId;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes a single vehicle
        /// </summary>
        /// <param name="vehicleID"></param>
        /// <returns>True if vehicle is PERMENENTLY removed</returns>
        public bool HardDeleteVehicle(Guid vehicleID)
        {
            int index = Vehicles.FindIndex(x => x.Id == vehicleID);
            if (index >= 0)
            {
                Vehicles.RemoveAt(index);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Sets the vehicle's IsDeleted
        /// </summary>
        /// <param name="vehicleID"></param>
        /// <returns>True if vehicle is there and IsDeleted is set</returns>
        public bool SoftDeleteVehicle(Guid vehicleID)
        {
            Vehicle vehicle = Vehicles.Where(x => x.Id == vehicleID).FirstOrDefault();

            if (vehicle != null)
            {
                vehicle.IsDeleted = true;
                return true;
            }
            return false;
        }

        public List<DataModels.Task> GetAllTasks(bool includeDeleted = false)
        {
            return new List<DataModels.Task>();
        }

        public bool AddTask(DataModels.Task task)
        {
            return false;
        }

        public bool UpdateTask(DataModels.Task task)
        {
            return false;
        }

        public bool HardDeleteTask(Guid taskID)
        {
            return false;
        }

        public bool SoftDeleteTask(Guid taskID)
        {
            return false;
        }
    }
}
