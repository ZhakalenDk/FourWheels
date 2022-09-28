using System.ComponentModel.DataAnnotations;

namespace ITGuru.FourWheels.Service
{
    public class VehicleDTO : IVehicle
    {
        [Required]
        public Guid Id { get; set; }
        [Required, MaxLength(7)]
        public string LicensePlate { get; set; }
        [MaxLength(25)]
        public string Brand { get; set; }
        [Required, MaxLength(25)]
        public string Model { get; set; }
        [Required]
        public Guid CustomerId { get; set; }
    }
}
