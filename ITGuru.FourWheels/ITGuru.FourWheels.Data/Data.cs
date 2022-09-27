using ITGuru.FourWheels.Data.DataModels;
using ITGuru.FourWheels.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITGuru.FourWheels.Data
{
    public class Data : IData
    {
        private List<Customer> Customers { get; set; } = new();

        public Data()
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
            return Customers.ToList();
        }

        public void SaveCustomerList(List<Customer> customers)
        {
            Customers = customers;
        }
    }
}
