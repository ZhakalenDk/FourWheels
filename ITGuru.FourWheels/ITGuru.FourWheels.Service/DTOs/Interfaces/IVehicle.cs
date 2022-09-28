namespace ITGuru.FourWheels.Service
{
    public interface IVehicle
    {
        Guid Id { get; }
        string LicensePlate { get; }
        string Brand { get; }
        string Model { get; }
        Guid CustomerId { get; }
    }
}
