using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITGuru.FourWheels.Service
{
    public class VehicleDTO : IVehicle
    {
        public Guid Id { get; }
        public string LicensePlate { get; }
        public string Brand { get; }
        public string Model { get; }
        public Guid CustomerId { get; }
    }
}
