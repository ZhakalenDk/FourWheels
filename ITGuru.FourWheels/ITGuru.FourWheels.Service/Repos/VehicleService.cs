using ITGuru.FourWheels.Data;

namespace ITGuru.FourWheels.Service
{
    public class VehicleService : IVehicleService
    {
        public RepoResult Add(IVehicle entity)
        {
            RepoResult result = new RepoResult("Vehicle added");
            try
            {
                if (!DataLayer.Data.AddVehicle(entity.MapToInternal()))
                {
                    result.Succeeded = false;
                    result.Message = "Vehicle couldn't be added";
                }
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.Exception = e;
                result.Succeeded = false;
            }

            return result;
        }

        public IReadOnlyList<IVehicle> GetAll()
        {
            return DataLayer.Data.GetAllVehicles()
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
                if (!DataLayer.Data.SoftDeleteVehicle(entity.Id))
                {
                    result.Succeeded = false;
                    result.Message = "Vehicle couldn't be removed";
                }
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.Exception = e;
                result.Succeeded = false;
            }

            return result;
        }

        public RepoResult Update(IVehicle entity)
        {
            RepoResult result = new RepoResult("Vehicle Updated");
            try
            {
                if (!DataLayer.Data.UpdateVehicle(entity.MapToInternal()))
                {
                    result.Succeeded = false;
                    result.Message = "Vehicle couldn't be updated";
                }
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.Exception = e;
                result.Succeeded = false;
            }

            return result;
        }
    }
}
