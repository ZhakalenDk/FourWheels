using ITGuru.FourWheels.Service;
using ITGuru.FourWheels.Service.Repos;
using ITGuru.FourWheels.Web.Enums;
using ITGuru.FourWheels.Web.ViewModels;
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
        public VehicleTasksVM VehicleTasksVM { get; set; }

        [BindProperty]
        public string Message { get; set; }

        [BindProperty]
        public MessageStatus MessageStatus { get; set; }

        public void OnGet(string VehicleId)
        {
            VehicleTasksVM = new VehicleTasksVM();

            var vehicle = _vehicleService.GetById(new Guid(VehicleId)) as VehicleDTO;
            Tasks = vehicle.GetTasks();

            VehicleTasksVM.LicensePlate = vehicle.LicensePlate;
            VehicleTasksVM.Brand = vehicle.Brand;
            VehicleTasksVM.Model = vehicle.Model;
            VehicleTasksVM.VehicleId = vehicle.Id;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                VehicleTasksVM.TaskId = Guid.NewGuid();

                var task = new TaskDTO()
                {
                    Id = VehicleTasksVM.TaskId,
                    AssociatedVehicleId = VehicleTasksVM.VehicleId,
                    OrderNumber = VehicleTasksVM.OrderNumber,
                    OrderDate = VehicleTasksVM.OrderDate,
                    Description = VehicleTasksVM.Description
                };
                var taskResult = _taskService.Add(task);
                if (taskResult.Succeeded)
                {
                    Message = $"Successfully created a new customer with a vehicle and a task!";
                    MessageStatus = MessageStatus.Success;
                    TempData["Message"] = Message;
                    TempData["MessageStatus"] = MessageStatus;
                    return RedirectToPage("/Administration/Tasks/VehicleTasks", VehicleTasksVM.VehicleId);
                }
                else
                {
                    Message = $"There was a mistake trying to add a customer with their vehicle and a task.";
                    MessageStatus = MessageStatus.Failed;
                    TempData["Message"] = Message;
                    TempData["MessageStatus"] = MessageStatus;
                    return RedirectToPage("/Administration/Tasks/VehicleTasks", VehicleTasksVM.VehicleId);
                }
            }
            else
            {
                Message = $"Validation on the inputs weren't acceptable!";
                MessageStatus = MessageStatus.Failed;
                TempData["Message"] = Message;
                TempData["MessageStatus"] = MessageStatus;
                OnGet(VehicleTasksVM.VehicleId.ToString());
                return Page();
            }
        }
    }
}
