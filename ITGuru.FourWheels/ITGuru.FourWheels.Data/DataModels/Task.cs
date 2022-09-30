using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITGuru.FourWheels.Data.DataModels
{
    public class Task
    {
        public Guid Id;
        //public Guid AssignedMechanic; Left in for later use
        public uint OrderNum;
        public DateTime OrderDate;
        public Guid Vehicle;
        //public List<Part> parts; Left in for later use
        public DateTime StartDate;
        public DateTime FinishDate;
        public string Description;
        public string Note;
        //public string Video; Left in for later use
    }
}
