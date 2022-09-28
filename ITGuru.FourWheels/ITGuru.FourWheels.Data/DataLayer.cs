using ITGuru.FourWheels.Data.DataModels;

namespace ITGuru.FourWheels.Data
{
    public class DataLayer : IDataLayer
    {
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

        public DataLayer()
        {
            GenerateList();
        }

        public void GenerateList()
        {
            Guid g = Guid.NewGuid();
            Customer customer = new Customer()
            {
                Id = g,
                FirstName = "jens",
                LastName = "Neergaard",
                Email = "jensneergaard@hotmail.com",
                Phone = "12345678"
            };
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

        public List<Customer> GetAllCustomers()
        {
            List<Customer> CustomerList = Customers.Where(x => x.Deleted != true).ToList();
            return CustomerList;
        }
        public List<Customer> GetAllDeletedCustomers()
        {
            List<Customer> DeletedList = Customers.Where(x => x.Deleted == true).ToList();
            return DeletedList;
        }

        /// <summary>
        /// Add a single Customer to the list
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>Return true if customer is added its NOT already in the list</returns>
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
        /// <returns> Return true if Customer is succesfully updated</returns>
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
        /// <returns>Return true if Customer is PERMENENTLY removed</returns>
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
        /// <returns>Return true if customer is there and IsDeleted is set</returns>
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

        public List<Vehicle> GetAllVehicles()
        {
            List<Vehicle> VehicleList = Vehicles.Where(x => x.IsDeleted != true).ToList();
            return VehicleList;
        }
        public List<Vehicle> GetAllDeletedVehicles()
        {
            List<Vehicle> VehicleList = Vehicles.Where(x => x.IsDeleted == true).ToList();
            return VehicleList;
        }

        /// <summary>
        /// Add a single Vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns>Return true if Vehicle is added and no Dublecate is added</returns>
        /// <exception cref="NotImplementedException"></exception>
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
        /// <returns>Return true if Vehicle is updated</returns>
        /// <exception cref="NotImplementedException"></exception>
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
        /// <returns>Return true if vehicle is PERMENENTLY removed</returns>
        /// <exception cref="NotImplementedException"></exception>
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
        /// <returns>Return true if vehicle is there and IsDeleted is set</returns>
        /// <exception cref="NotImplementedException"></exception>
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
    }
}
