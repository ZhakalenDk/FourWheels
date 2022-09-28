﻿using ITGuru.FourWheels.Data.DataModels;
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

        public bool AddCustomer(Customer customer)
        {

            Customers.Add(customer);
            return true;
        }

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
            }
            return true;
        }

        public bool HardDeleteCustomer(Guid customerID)
        {
            int index = Customers.FindIndex(x => x.Id == customerID);
            Customers.RemoveAt(index);
            return true;
        }

        public bool SoftDeleteCustomer(Guid customerID)
        {
            Customer customer = Customers.Where(x => x.Id == customerID).FirstOrDefault();

            if (customer != null)
            {
                customer.Deleted = true;
            }
            return true;
        }

        public List<Vehicle> GetAllVehicles()
        {
            throw new NotImplementedException();
        }

        public bool AddVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public bool UpdateVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public bool HardDeleteVehicle(Guid vehicleID)
        {
            throw new NotImplementedException();
        }

        public bool SoftDeleteVehicle(Guid vehicleID)
        {
            throw new NotImplementedException();
        }
    }
}