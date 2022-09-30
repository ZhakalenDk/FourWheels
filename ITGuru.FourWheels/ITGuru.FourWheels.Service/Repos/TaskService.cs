using ITGuru.FourWheels.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ITGuru.FourWheels.Service.Repos
{
    public class TaskService : ITaskService
    {
        public TaskService()
        {
            _data = DataLayer.Data;
        }

        private readonly IDataLayer _data;

        public RepoResult Add(ITask entity)
        {
            RepoResult result = new RepoResult("Task Added");
            try
            {
                if (!_data.AddTask(entity.MapToInternal()))
                {
                    result.Succeeded = false;
                    result.Message = "Task couldn't be added";
                }
            }
            catch (Exception e)
            {
                result.Exception = e;
                result.Message = e.Message;
                result.Succeeded = false;
            }

            return result;
        }

        public IReadOnlyList<ITask> GetAll()
        {
            return _data.GetAllTasks()
                .MapToPublic()
                .ToList();
        }

        public ITask GetById(Guid key)
        {
            return _data.GetAllTasks()
                 .FirstOrDefault(t => t.Id == key)
                 .MapToPublic();
        }

        public RepoResult Remove(ITask entity)
        {
            RepoResult result = new RepoResult("Task Removed");
            try
            {
                if (!_data.AddTask(entity.MapToInternal()))
                {
                    result.Succeeded = false;
                    result.Message = "Task couldn't be Removed";
                }
            }
            catch (Exception e)
            {
                result.Exception = e;
                result.Message = e.Message;
                result.Succeeded = false;
            }

            return result;
        }

        public RepoResult Update(ITask entity)
        {
            RepoResult result = new RepoResult("Task Updated");
            try
            {
                if (!_data.AddTask(entity.MapToInternal()))
                {
                    result.Succeeded = false;
                    result.Message = "Task couldn't be Updated";
                }
            }
            catch (Exception e)
            {
                result.Exception = e;
                result.Message = e.Message;
                result.Succeeded = false;
            }

            return result;
        }
    }
}
