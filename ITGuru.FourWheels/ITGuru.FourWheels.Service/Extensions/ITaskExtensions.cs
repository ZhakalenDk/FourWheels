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
        //#region Mappers
        //private static readonly Mapper<ITask, Task> _internalMapper = new((t, f) =>
        //{
        //    t.Email = f.Email;
        //    t.FirstName = f.FirstName;
        //    t.Id = f.Id;
        //    t.LastName = f.LastName;
        //    t.Phone = f.Phone;

        //    return t;
        //});

        //private static readonly Mapper<Task, TaskDTO> _publicMapper = new((t, f) =>
        //{
        //    t.Email = f.Email;
        //    t.FirstName = f.FirstName;
        //    t.Id = f.Id;
        //    t.LastName = f.LastName;
        //    t.Phone = f.Phone;

        //    return t;
        //});
        //#endregion

        //internal static Task MapToInternal(this ITask task)
        //{
        //    return _internalMapper.FromSingle(task);
        //}

        //internal static ITask MapToPublic(this Task task)
        //{
        //    return _publicMapper.FromSingle(task);
        //}

        //internal static IEnumerable<ITask> MapToPublic(this IEnumerable<Task> tasks)
        //{
        //    return _publicMapper.FromCollection(tasks);
        //}
    }
}
