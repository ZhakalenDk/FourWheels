using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITGuru.FourWheels.Service
{
    public class TaskDTO : ITask
    {
        public Guid Id { get; set; }
        [Required]
        public string OrderNumber { get; set; }
        //public Guid AssignedMechanicId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public Guid AssociatedVehicleId { get; set; }
        [Required]
        public string Description { get; set; }
        public string Notes { get; set; }
    }
}
