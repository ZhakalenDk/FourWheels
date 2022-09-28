﻿namespace ITGuru.FourWheels.Service
{
    public class VehicleDTO : IVehicle
    {
        public Guid Id { get; set; }
        public string LicensePlate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public Guid CustomerId { get; set; }
    }
}
