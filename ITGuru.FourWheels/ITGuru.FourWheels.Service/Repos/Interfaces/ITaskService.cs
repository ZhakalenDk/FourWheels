using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITGuru.FourWheels.Service
{
    public interface ITaskService : ICRUDRepo<ITask, Guid, RepoResult>
    {
    }
}
