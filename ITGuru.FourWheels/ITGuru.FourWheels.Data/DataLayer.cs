using ITGuru.FourWheels.Data.DataModels;
using ITGuru.FourWheels.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITGuru.FourWheels.Data
{
    public class DataLayer : IDataLayer
    {
        private List<Customer> _customers = new();
        public List<Customer> Customers
        {
            get { return _customers; }
        }
        public DataLayer()
        {
            GenerateList();
        }
        public void GenerateList()
        {
            Guid g = Guid.NewGuid();
            Customer customer = new()
            {
                Id = g,
                FirstName = "jens",
                LastName = "Neergaard",
                Email = "jensneergaard@hotmail.com",
                Phone = "12345678"
            };
            Customers.Add(customer);

            Guid g2 = Guid.NewGuid();
            Customer customer2 = new()
            {
                Id = g2,
                FirstName = "Mike",
                LastName = "Mortensen",
                Email = "MikeMortensen@hotmail.com",
                Phone = "23456789"
            };
            Customers.Add(customer2);

            Guid g3 = Guid.NewGuid();
            Customer customer3 = new()
            {
                Id = g3,
                FirstName = "Lukas",
                LastName = "Pederson",
                Email = "LukasPederson@hotmail.com",
                Phone = "34567890"
            };
            Customers.Add(customer3);

            Guid g4 = Guid.NewGuid();
            Customer customer4 = new()
            {
                Id = g4,
                FirstName = "Simon",
                LastName = "Andreassen",
                Email = "SimonAndreassen@hotmail.com",
                Phone = "23456789"
            };
            Customers.Add(customer4);

            Guid g5 = Guid.NewGuid();
            Customer customer5 = new()
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
            return Customers.ToList();
        }
        /// <summary>
        /// Adds a single customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>Return true if Added without a dublecate</returns>
        public bool AddCustomer(Customer customer)
        {
            int index = Customers.IndexOf(customer);
            if (index >= 0)
            {
                Customers.Add(customer);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Updates a single customer
        /// </summary>
        /// <param name="changed_customer"></param>
        /// <returns> return true if customer is there and updated</returns>
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
        /// Removes a single customer
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns> Return true if customer is deleted PERMAMENTLY</returns>
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
          /// SoftDelete a single customer
          /// </summary>
          /// <param name="customerID"></param>
          /// <returns> Return true if customer is soft deleted</returns>
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

    }
}
