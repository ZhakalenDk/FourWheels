using ITGuru.FourWheels.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITGuru.FourWheels.Data.Interfaces
{
    public interface IData
    {
        void GenerateList();
        List<Customer> GetAllCustomers();
        void SaveCustomerList(List<Customer> customers);
    }
}
