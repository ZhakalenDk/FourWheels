using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITGuru.FourWheels.Service
{
    public interface ITask
    {
        public Guid Id { get; }
        public string OrderNumber { get; }
        //public Guid AssignedMechanicId { get; }
        public DateTime OrderData { get; }
        public DateTime StartDate { get; }
        public DateTime FinishDate { get; }
        public Guid AssociatedVehicle { get; }
        public string Description { get; }
        public string Notes { get; }
    }
}
