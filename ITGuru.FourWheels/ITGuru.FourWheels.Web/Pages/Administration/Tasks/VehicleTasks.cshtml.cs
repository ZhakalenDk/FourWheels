using ITGuru.FourWheels.Service;
using ITGuru.FourWheels.Service.Repos;
using ITGuru.FourWheels.Web.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITGuru.FourWheels.Web.Pages.Administration.Tasks
{
    public class VehicleTasksModel : PageModel
    {
        public VehicleTasksModel(ITaskService taskService, IVehicleService vehicleService)
        {
            _taskService = taskService;
            _vehicleService = vehicleService;
        }

        private readonly IVehicleService _vehicleService;
        private readonly ITaskService _taskService;

        [BindProperty]
        public IReadOnlyList<ITask> Tasks { get; set; }

        [BindProperty]
        public IVehicle Vehicle { get; set; }

        [BindProperty]
        public ITask Task { get; set; }

        [BindProperty]
        public string Message { get; set; }

        [BindProperty]
        public MessageStatus MessageStatus { get; set; }

        public void OnGet(string VehicleId)
        {
            Vehicle = _vehicleService.GetById(new Guid(VehicleId)) as VehicleDTO;
            Tasks = Vehicle.GetTasks();
        }
    }
}
