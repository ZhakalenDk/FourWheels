namespace ITGuru.FourWheels.Data.DataModels
{
    public class Task
    {
        public Guid Id;
        //public Guid AssignedMechanic; Left in for later use
        public string OrderNum;
        public DateTime OrderDate;
        public Guid VehicleId;
        //public List<Part> parts; Left in for later use
        public DateTime StartDate;
        public DateTime FinishDate;
        public string Description;
        public string Note;
        //public string Video; Left in for later use
    }
}
