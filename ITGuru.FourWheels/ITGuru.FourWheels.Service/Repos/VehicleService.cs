using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITGuru.FourWheels.Service.Repos
{
    public class VehicleService : IVehicleService
    {
        public RepoResult Add(IVehicle entity)
        {
            //  TODO: Implement Add functionality

            return new RepoResult("Test Result");
        }

        public IReadOnlyList<IVehicle> GetAll()
        {
            //  TODO: Implement GetAll functionality

            return new List<IVehicle>();
        }

        public IVehicle GetById(Guid key)
        {
            //  TODO: Implement Add functionality

            return new VehicleDTO();
        }

        public RepoResult Remove(IVehicle entity)
        {
            //  TODO: Implement Remove functionality

            return new RepoResult("Test Result");
        }

        public RepoResult Update(IVehicle entity)
        {
            //  TODO: Implement Update functionality

            return new RepoResult("Test Result");
        }
    }
}
