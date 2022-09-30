using ITGuru.FourWheels.Data.DataModels;

namespace ITGuru.FourWheels.Data
{
    public interface IDataLayer
    {
        void GenerateList();
        //Customer
        List<Customer> GetAllCustomers(bool includeDeleted = false);
        bool AddCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool HardDeleteCustomer(Guid customerID);
        bool SoftDeleteCustomer(Guid customerID);
        // Vehicle
        List<Vehicle> GetAllVehicles(bool includeDeleted = false);
        bool AddVehicle(Vehicle vehicle);
        bool UpdateVehicle(Vehicle vehicle);
        bool HardDeleteVehicle(Guid vehicleID);
        bool SoftDeleteVehicle(Guid vehicleID);
        //Employee
        //List<Employee> GetAllEmployees(bool includeDeleted = false); Left in for later use
        //bool AddEmployee(Employee employee); Left in for later use
        //bool UpdateEmployee(Employee employee); Left in for later use
        //bool SoftDeleteEmployee(Guid employeeID); Left in for later use
        //bool HardDeleteEmployee(Guid employeeID); Left in for later use
        //Task
        List<DataModels.Task> GetAllTasks(bool includeDeleted = false);
        bool AddTask(DataModels.Task task);
        bool UpdateTask(DataModels.Task task);
        bool HardDeleteTask(Guid taskID);
        bool SoftDeleteTask(Guid taskID);
        
    }
}
