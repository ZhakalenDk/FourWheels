using ITGuru.FourWheels.Data;

namespace ITGuru.FourWheels.Service
{
    public class VehicleService : IVehicleService
    {
        public VehicleService(IDataLayer context)
        {
            _context = context;
        }

        private readonly IDataLayer _context;

        public RepoResult Add(IVehicle entity)
        {
            RepoResult result = new RepoResult("Vehicle added");
            try
            {
                if (!_context.AddVehicle(entity.MapToInternal()))
                {
                    result.Message = "Vehicle couldn't be added";
                }
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.Exception = e;
            }

            return result;
        }

        public IReadOnlyList<IVehicle> GetAll()
        {
            return _context.GetAllVehicles()
                .MapToPublic()
                .ToList();
        }

        public IVehicle GetById(Guid key)
        {
            return GetAll().FirstOrDefault(v => v.Id == key);
        }

        public RepoResult Remove(IVehicle entity)
        {
            RepoResult result = new RepoResult("Vehicle Removed");
            try
            {
                if (!_context.SoftDeleteVehicle(entity.Id))
                {
                    result.Message = "Vehicle couldn't be removed";
                }
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.Exception = e;
            }

            return result;
        }

        public RepoResult Update(IVehicle entity)
        {
            RepoResult result = new RepoResult("Vehicle Updated");
            try
            {
                if (!_context.UpdateVehicle(entity.MapToInternal()))
                {
                    result.Message = "Vehicle couldn't be updated";
                }
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.Exception = e;
            }

            return result;
        }
    }
}
