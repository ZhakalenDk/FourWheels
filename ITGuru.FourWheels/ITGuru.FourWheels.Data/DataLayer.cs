using ITGuru.FourWheels.Data.DataModels;
using System.Runtime.CompilerServices;

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
                lock (_lockObject)
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

        private List<DataModels.Task> _tasks;
        public List<DataModels.Task> Tasks
        {
            get { return _tasks; }
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

        private Guid GenerateVehicleList(Guid customerID, string brand, string model, string licensePlate)
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
            return guid;
        }
        private void GenerateTask(string _orderNum, DateTime _OrderDate, Guid _VehicleId, DateTime _StartDate, DateTime _FinishDate, string _Descroption, string _Note)
        {
            Guid guid = new();
            DataModels.Task task = new()
            {
                IsDeleted = false,
                OrderNum = _orderNum,
                OrderDate = _OrderDate,
                VehicleId = _VehicleId,
                StartDate = _StartDate,
                FinishDate = _FinishDate,
                Description = _Descroption,
                Note = _Note
            };
            Tasks.Add(task);
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
            Guid vehicleId1 = GenerateVehicleList(g, "Rolls-Royce", "Rolls-Royce Spectre (electric)", "RR66449");
            GenerateTask(
                "FW1000",
                DateTime.Today.AddDays(-5),
                vehicleId1,
                DateTime.Today.AddDays(-4),
                DateTime.Today,
                "funny sound from the right side",
                "Changed the Breaks and added oil");
            GenerateTask(
                "FW1001",
                DateTime.Today.AddMonths(-2).AddDays(-5),
                vehicleId1,
                DateTime.Today.AddMonths(-2).AddDays(-4),
                DateTime.Today.AddMonths(-2),
                "Checkup",
                "Changed the oil, looked at the engion nothing seemed to be wrong");
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
            Guid vehicleId2_1 = GenerateVehicleList(g2, "Volkswagen", "GOLF", "VW45697");

            GenerateTask(
                "FW1002",
                DateTime.Today.AddMonths(-2).AddDays(-5),
                vehicleId2_1,
                DateTime.Today.AddMonths(-2).AddDays(-4),
                DateTime.Today.AddMonths(-2),
                "Checkup",
                "Changed the oil, looked at the engion nothing seemed to be wrong");
            Guid vehicleId2_2 = GenerateVehicleList(g2, "Cadilac", "XT5", "CC12345");
            GenerateTask(
                "FW1003",
                DateTime.Today.AddMonths(-2).AddDays(-5),
                vehicleId2_2,
                DateTime.Today.AddMonths(-2).AddDays(-4),
                DateTime.Today.AddMonths(-2),
                "Checkup",
                "Changed the oil, looked at the engion nothing seemed to be wrong but a bird hade made its home in the back of the car. ");
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
            Guid vehicleId3_1 = GenerateVehicleList(g3, "BMW", "1 Series (F52)", "The Boss 2");

            GenerateTask(
                "FW1004",
                DateTime.Today.AddMonths(-4).AddDays(-5),
                vehicleId3_1,
                DateTime.Today.AddMonths(-4).AddDays(-4),
                DateTime.Today.AddMonths(-4),
                "Checkup",
                "Changed the oil, looked at the engion nothing seemed to be wrong");

            GenerateTask(
                "FW1005",
                DateTime.Today.AddMonths(-3).AddDays(-5),
                vehicleId3_1,
                DateTime.Today.AddMonths(-3).AddDays(-4),
                DateTime.Today.AddMonths(-3),
                "Checkup",
                "Changed the oil, looked at the engion nothing seemed to be wrong");

            GenerateTask(
                "FW1006",
                DateTime.Today.AddMonths(-2).AddDays(-5),
                vehicleId3_1,
                DateTime.Today.AddMonths(-2).AddDays(-4),
                DateTime.Today.AddMonths(-2),
                "Checkup",
                "Changed the oil, looked at the engion nothing seemed to be wrong");

            GenerateTask(
                "FW1007",
                DateTime.Today.AddMonths(-1).AddDays(-5),
                vehicleId3_1,
                DateTime.Today.AddMonths(-1).AddDays(-4),
                DateTime.Today.AddMonths(-1),
                "Checkup",
                "Changed the oil, looked at the engion nothing seemed to be wrong");

            GenerateTask(
                "FW1008",
                DateTime.Today.AddDays(-5),
                vehicleId3_1,
                DateTime.Today.AddDays(-4),
                DateTime.Today,
                "Checkup",
                "Changed the oil, Changed the breaks, polished the mirrors");

            Guid vehicleId3_2 = GenerateVehicleList(g3, "BMW", "5 Series", "The Boss");

            GenerateTask(
                "FW1009",
                DateTime.Today.AddMonths(-2).AddDays(-5),
                vehicleId3_2,
                DateTime.Today.AddMonths(-2).AddDays(-4),
                DateTime.Today.AddMonths(-2),
                "Checkup",
                "Changed the oil, looked at the engion nothing seemed to be wrong");

            GenerateTask(
                "FW1010",
                DateTime.Today.AddMonths(-2).AddDays(-5),
                vehicleId3_2,
                DateTime.Today.AddMonths(-2).AddDays(-4),
                DateTime.Today.AddMonths(-2),
                "Checkup",
                "Changed the oil, looked at the engion nothing seemed to be wrong");

            GenerateTask(
                "FW1011",
                DateTime.Today.AddMonths(-2).AddDays(-5),
                vehicleId3_2,
                DateTime.Today.AddMonths(-2).AddDays(-4),
                DateTime.Today.AddMonths(-2),
                "Checkup",
                "Changed the oil, looked at the engion nothing seemed to be wrong");

            GenerateTask(
                "FW1012",
                DateTime.Today.AddMonths(-2).AddDays(-5),
                vehicleId3_2,
                DateTime.Today.AddMonths(-2).AddDays(-4),
                DateTime.Today.AddMonths(-2),
                "Checkup",
                "Changed the oil, looked at the engion nothing seemed to be wrong");

            GenerateTask(
                "FW1013",
                DateTime.Today.AddMonths(-2).AddDays(-5),
                vehicleId3_2,
                DateTime.Today.AddMonths(-2).AddDays(-4),
                DateTime.Today.AddMonths(-2),
                "Checkup",
                "Changed the oil, looked at the engion nothing seemed to be wrong");

            GenerateTask(
                "FW1014",
                DateTime.Today.AddMonths(-2).AddDays(-5),
                vehicleId3_2,
                DateTime.Today.AddMonths(-2).AddDays(-4),
                DateTime.Today.AddMonths(-2),
                "Checkup",
                "Changed the oil, looked at the engion nothing seemed to be wrong");

            GenerateTask(
                "FW1015",
                DateTime.Today.AddMonths(-2).AddDays(-5),
                vehicleId3_2,
                DateTime.Today.AddMonths(-2).AddDays(-4),
                DateTime.Today.AddMonths(-2),
                "Checkup",
                "Changed the oil, looked at the engion nothing seemed to be wrong");

            GenerateTask(
                "FW1016",
                DateTime.Today.AddMonths(-2).AddDays(-5),
                vehicleId3_2,
                DateTime.Today.AddMonths(-2).AddDays(-4),
                DateTime.Today.AddMonths(-2),
                "Checkup",
                "Changed the oil, looked at the engion nothing seemed to be wrong");
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
            Guid vehicleId4_1 = GenerateVehicleList(g4, "Cadilac", "XT6", "CC34598");

            GenerateTask(
                "FW1017",
                DateTime.Today.AddMonths(-2).AddDays(-5),
                vehicleId3_1,
                DateTime.Today.AddMonths(-2).AddDays(-4),
                DateTime.Today.AddMonths(-2),
                "Checkup",
                "Changed the oil, looked at the engion nothing seemed to be wrong");
            Guid vehicleId4_2 = GenerateVehicleList(g4, "Cadilac", "CT4", "CC23584");

            GenerateTask(
                "FW1018",
                DateTime.Today.AddDays(-5),
                vehicleId3_1,
                DateTime.Today.AddDays(-4),
                DateTime.Today,
                "Checkup",
                "Changed the oil, looked at the engion nothing seemed to be wrong");
            Guid vehicleId4_3 = GenerateVehicleList(g4, "Cadilac", "ESCALADE ESV", "CC98765");
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
            List<DataModels.Task> TaskList = Tasks.Where(x => x.IsDeleted == includeDeleted).ToList();
            return TaskList;
        }

        /// <summary>
        /// Add a single Task to the list
        /// </summary>
        /// <param name="task"></param>
        /// <returns>True of Task succefully added</returns>
        public bool AddTask(DataModels.Task task)
        {
            int index = Tasks.FindIndex(x => x.Id == task.Id);
            if (index >= 0)
            {
                return false;
            }
            else
            {
                Tasks.Add(task);
                return true;
            }
        }

        /// <summary>
        /// Update a single Task
        /// </summary>
        /// <param name="task"></param>
        /// <returns>True if succefully found and changed a task</returns>
        public bool UpdateTask(DataModels.Task task)
        {
            DataModels.Task taskNew = Tasks.Where(x => x.Id == task.Id).FirstOrDefault();

            if (taskNew != null)
            {
                taskNew.OrderNum = task.OrderNum;
                taskNew.OrderDate = task.OrderDate;
                taskNew.VehicleId = task.VehicleId;
                taskNew.StartDate = task.StartDate;
                taskNew.FinishDate = task.FinishDate;
                taskNew.Description = task.Description;
                taskNew.Note = task.Note;

                return true;
            }
            return false;
        }

        /// <summary>
        /// PERMENENTLY remove a Task
        /// </summary>
        /// <param name="taskID"></param>
        /// <returns>True if Task found and removed from list</returns>
        public bool HardDeleteTask(Guid taskID)
        {
            int index = Tasks.FindIndex(x => x.Id == taskID);
            if (index >= 0)
            {
                Tasks.RemoveAt(index);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Soft removes a task from the list
        /// </summary>
        /// <param name="taskID"></param>
        /// <returns>True if task found and IsDeleted changed to true </returns>
        public bool SoftDeleteTask(Guid taskID)
        {
            DataModels.Task taskToDelete = Tasks.Where(x => x.Id == taskID).FirstOrDefault();

            if (taskToDelete != null)
            {
                taskToDelete.IsDeleted = true;
                return true;
            }
            return false;
        }
    }
}
