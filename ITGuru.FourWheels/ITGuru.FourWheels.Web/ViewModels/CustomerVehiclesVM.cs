using System.ComponentModel.DataAnnotations;

namespace ITGuru.FourWheels.Web.ViewModels
{
    public class CustomerVehiclesVM
    {
        public Guid VehicleId { get; set; }
        public Guid CustomerId { get; set; }

        [Required]
        public string LicensePlate { get; set; }
        [Required]
        [MaxLength(60)]
        public string Brand { get; set; }
        [Required]
        [MaxLength(60)]
        public string Model { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
