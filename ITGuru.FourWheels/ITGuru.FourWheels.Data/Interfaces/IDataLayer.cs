using ITGuru.FourWheels.Data.DataModels;

namespace ITGuru.FourWheels.Data
{
    public interface IDataLayer
    {
        void GenerateList();
        List<Customer> GetAllCustomers(bool getDeleted);
        bool AddCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool HardDeleteCustomer(Guid customerID);
        bool SoftDeleteCustomer(Guid customerID);
        List<Vehicle> GetAllVehicles(bool getDeleted);
        bool AddVehicle(Vehicle vehicle);
        bool UpdateVehicle(Vehicle vehicle);
        bool HardDeleteVehicle(Guid vehicleID);
        bool SoftDeleteVehicle(Guid vehicleID);
    }
}