using ITGuru.FourWheels.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITGuru.FourWheels.Tests
{
    internal static class AssertMulti
    {
        // Customer
        public static void AllCustomerProperties(ICustomer exptectedCustomer, ICustomer actualCustomer)
        {
            Assert.Equal(exptectedCustomer.Id, actualCustomer.Id);
            Assert.Equal(exptectedCustomer.FirstName, actualCustomer.FirstName);
            Assert.Equal(exptectedCustomer.LastName, actualCustomer.LastName);
            Assert.Equal(exptectedCustomer.Phone, actualCustomer.Phone);
            Assert.Equal(exptectedCustomer.Email, actualCustomer.Email);
        }

        // Vehicle
        public static void AllVehicleProperties(IVehicle exptectedVehicle, IVehicle actualVehicle)
        {
            Assert.Equal(exptectedVehicle.Id, actualVehicle.Id);
            Assert.Equal(exptectedVehicle.Brand, actualVehicle.Brand);
            Assert.Equal(exptectedVehicle.Model, actualVehicle.Model);
            Assert.Equal(exptectedVehicle.LicensePlate, actualVehicle.LicensePlate);
            Assert.Equal(exptectedVehicle.CustomerId, actualVehicle.CustomerId);
        }

        // Task
        public static void AllTaskProperties(ITask exptectedTask, ITask actualTask)
        {
            Assert.Equal(exptectedTask.Id, actualTask.Id);
            Assert.Equal(exptectedTask.OrderNumber, actualTask.OrderNumber);
            Assert.Equal(exptectedTask.OrderDate, actualTask.OrderDate);
            Assert.Equal(exptectedTask.StartDate, actualTask.StartDate);
            Assert.Equal(exptectedTask.FinishDate, actualTask.FinishDate);
            Assert.Equal(exptectedTask.AssociatedVehicleId, actualTask.AssociatedVehicleId);
            Assert.Equal(exptectedTask.Description, actualTask.Description);
            Assert.Equal(exptectedTask.Notes, actualTask.Notes);
            Assert.Equal(exptectedTask.Description, actualTask.Description);
            Assert.Equal(exptectedTask.AssociatedVehicleId, actualTask.AssociatedVehicleId);
        }
    }
}
