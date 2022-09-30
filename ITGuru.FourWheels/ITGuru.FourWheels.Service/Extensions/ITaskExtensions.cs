using ITGuru.FourWheels.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITGuru.FourWheels.Service
{
    public static class ITaskExtensions
    {
        #region Mappers
        private static readonly Mapper<ITask, Data.DataModels.Task> _internalMapper = new((t, f) =>
        {
            t.Description = f.Description;
            t.FinishDate = f.FinishDate;
            t.Id = f.Id;
            t.Note = f.Notes;
            t.OrderDate = f.OrderDate;
            t.OrderNum = f.OrderNumber;
            t.StartDate = f.StartDate;
            t.VehicleId = f.AssociatedVehicleId;

            return t;
        });

        private static readonly Mapper<Data.DataModels.Task, TaskDTO> _publicMapper = new((t, f) =>
        {
            t.Description = f.Description;
            t.FinishDate = f.FinishDate;
            t.Id = f.Id;
            t.Notes = f.Note;
            t.OrderDate = f.OrderDate;
            t.OrderNumber = f.OrderNum;
            t.StartDate = f.StartDate;
            t.AssociatedVehicleId = f.VehicleId;

            return t;
        });
        #endregion

        internal static Data.DataModels.Task MapToInternal(this ITask task)
        {
            return _internalMapper.FromSingle(task);
        }

        internal static ITask MapToPublic(this Data.DataModels.Task task)
        {
            return _publicMapper.FromSingle(task);
        }

        internal static IEnumerable<ITask> MapToPublic(this IEnumerable<Data.DataModels.Task> tasks)
        {
            return _publicMapper.FromCollection(tasks);
        }
    }
}
