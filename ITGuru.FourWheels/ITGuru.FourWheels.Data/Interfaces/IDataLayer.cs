using ITGuru.FourWheels.Data.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITGuru.FourWheels.Data.Interfaces
{
    public interface IDataLayer
    {
        void GenerateList();
        List<Customer> GetAllCustomers();
        bool AddCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool HardDeleteCustomer(Guid customerID);
        bool SoftDeleteCustomer(Guid customerID);
    }
}
