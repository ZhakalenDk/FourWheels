using ITGuru.FourWheels.DataLayer.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITGuru.FourWheels.DataLayer
{
    public interface IDataLayer
    {
        void GenerateList();
        List<Customer> GetAllCustomers();
        bool AddCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool HardDeleteCustomer(Guid customerID);
        bool SoftDeleteCustomer(Guid customerID);
        List<Vehicle> GetAllVehicles();
        bool AddVehicle(Vehicle vehicle);
        bool UpdateVehicle(Vehicle vehicle);
        bool HardDeleteVehicle(Guid vehicleID);
        bool SoftDeleteVehicle(Guid vehicleID);
    }
}
