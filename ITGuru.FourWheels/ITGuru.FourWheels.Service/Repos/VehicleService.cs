using ITGuru.FourWheels.Data;

namespace ITGuru.FourWheels.Service
{
    public class VehicleService : IVehicleService
    {
        public VehicleService()
        {
            _data = DataLayer.Data;
        }
        private IDataLayer _data;

        public RepoResult Add(IVehicle entity)
        {
            RepoResult result = new RepoResult("Vehicle added");
            try
            {
                if (!_data.AddVehicle(entity.MapToInternal()))
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
            return _data.GetAllVehicles()
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
                if (!_data.SoftDeleteVehicle(entity.Id))
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
                if (!_data.UpdateVehicle(entity.MapToInternal()))
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
