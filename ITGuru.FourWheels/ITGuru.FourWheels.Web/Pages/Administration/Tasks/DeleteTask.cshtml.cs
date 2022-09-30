using ITGuru.FourWheels.Service;
using ITGuru.FourWheels.Web.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITGuru.FourWheels.Web.Pages.Administration.Tasks
{
    public class DeleteTaskModel : PageModel
    {
        private readonly ITaskService _taskService;
        public DeleteTaskModel(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [BindProperty]
        public TaskDTO Task { get; set; }



        public void OnGet(string taskId)
        {
            Task = _taskService.GetById(new Guid(taskId)) as TaskDTO;
        }

        public IActionResult OnPost()
        {
            if (_taskService.Remove(Task).Succeeded)
            {
                TempData["Message"] = $"Successfully delete the task {Task.Description}";
                TempData["MessageStatus"] = MessageStatus.Success;
                return Redirect($"/Administration/Tasks/VehicleTasks/{Task.AssociatedVehicleId}");
            }
            else
            {
                TempData["Message"] = $"Couldn't delete task {Task.Description}";
                TempData["MessageStatus"] = MessageStatus.Failed;
                return Redirect($"/Administration/Tasks/VehicleTasks/{Task.AssociatedVehicleId}");
            }
        }
    }
}
