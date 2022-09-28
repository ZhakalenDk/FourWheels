using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITGuru.FourWheels.Data.DataModels
{
    public class Vehicle
    {
        public Guid Id;
        public string LicensePlate;
        public string Brand;
        public string Model;
        public Guid CustomerId;
        public bool IsDeleted;
    }
}
