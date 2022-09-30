using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITGuru.FourWheels.Service
{
    public class TaskDTO : ITask
    {
        public Guid Id { get; set; }
        public string OrderNumber { get; set; }
        //public Guid AssignedMechanicId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public Guid AssociatedVehicleId { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
    }
}
