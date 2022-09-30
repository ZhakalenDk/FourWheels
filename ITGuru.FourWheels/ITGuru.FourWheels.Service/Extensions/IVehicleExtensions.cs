using ITGuru.FourWheels.Data.DataModels;

namespace ITGuru.FourWheels.Service
{
    public static class IVehicleExtensions
    {
        #region Mappers
        private static readonly Mapper<IVehicle, Vehicle> _internalMapper = new((t, f) =>
        {
            t.Brand = f.Brand;
            t.CustomerId = f.CustomerId;
            t.Id = f.Id;
            t.LicensePlate = f.LicensePlate;
            t.Model = f.Model;

            return t;
        });

        private static readonly Mapper<Vehicle, VehicleDTO> _publicMapper = new((t, f) =>
        {
            t.Brand = f.Brand;
            t.CustomerId = f.CustomerId;
            t.Id = f.Id;
            t.LicensePlate = f.LicensePlate;
            t.Model = f.Model;

            return t;
        });
        #endregion

        internal static Vehicle MapToInternal(this IVehicle vehicle)
        {
            return _internalMapper.FromSingle(vehicle);
        }

        internal static IVehicle MapToPublic(this Vehicle vehicle)
        {
            return _publicMapper.FromSingle(vehicle);
        }

        internal static IEnumerable<IVehicle> MapToPublic(this IEnumerable<Vehicle> vehicles)
        {
            return _publicMapper.FromCollection(vehicles);
        }

        public static IReadOnlyList<ITask> GetTasks(this IVehicle vehicle)
        {
            //  TODO: GetTasks for vehicles

            return null;
        }
    }
}
