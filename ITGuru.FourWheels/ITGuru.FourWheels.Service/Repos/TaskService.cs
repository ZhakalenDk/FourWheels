using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITGuru.FourWheels.Service.Repos
{
    public class TaskService : ITaskService
    {
        public RepoResult Add(ITask entity)
        {
            //  TODO: IMplement Add

            return new RepoResult("Test");
        }

        public IReadOnlyList<ITask> GetAll()
        {
            //  TODO: IMplement GetAll

            return new List<ITask>();
        }

        public ITask GetById(Guid key)
        {
            //  TODO: IMplement Add

            return new TaskDTO();
        }

        public RepoResult Remove(ITask entity)
        {
            //  TODO: IMplement Remove

            return new RepoResult("Test");
        }

        public RepoResult Update(ITask entity)
        {
            //  TODO: IMplement Update

            return new RepoResult("Test");
        }
    }
}
