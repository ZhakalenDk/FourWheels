using System.ComponentModel.DataAnnotations;

namespace ITGuru.FourWheels.Web.ViewModels
{
    public class VehicleTasksVM
    {
        public Guid VehicleId { get; set; }
        public Guid TaskId { get; set; }
        [Required]
        public string OrderNumber { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public string Description { get; set; }
        public string LicensePlate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
    }
}
