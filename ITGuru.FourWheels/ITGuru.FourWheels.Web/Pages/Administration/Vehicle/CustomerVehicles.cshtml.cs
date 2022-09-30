using ITGuru.FourWheels.Data.DataModels;
using ITGuru.FourWheels.Service;
using ITGuru.FourWheels.Service.Repos;
using ITGuru.FourWheels.Web.Enums;
using ITGuru.FourWheels.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.WebSockets;

namespace ITGuru.FourWheels.Web.Pages.Administration.Vehicle
{
    public class CustomerVehiclesModel : PageModel
    {
        private readonly ICustomerService _customerService;
        private readonly IVehicleService _vehicleService;
        private readonly ITaskService _taskService;
        public CustomerVehiclesModel(ICustomerService customerService, IVehicleService vehicleService, ITaskService taskService)
        {
            _customerService = customerService;
            _vehicleService = vehicleService;
            _taskService = taskService;
        }

        [BindProperty]
        public IReadOnlyList<IVehicle> Vehicles { get; set; }

        [BindProperty]
        public CustomerVehiclesVM CustomerVehicle { get; set; }

        [BindProperty]
        public TaskDTO Task { get; set; }

        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public MessageStatus MessageStatus { get; set; }

        public void OnGet(string CustomerId)
        {
            CustomerVehicle = new();

            var Customer = _customerService.GetById(new Guid(CustomerId)) as CustomerDTO;
            Vehicles = Customer.GetVehicles();

            CustomerVehicle.FirstName = Customer.FirstName;
            CustomerVehicle.LastName = Customer.LastName;
            CustomerVehicle.CustomerId = Customer.Id;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                CustomerVehicle.VehicleId = Guid.NewGuid();
                VehicleDTO vehicle = new VehicleDTO
                {
                    Id = CustomerVehicle.VehicleId,
                    Brand = CustomerVehicle.Brand,
                    Model = CustomerVehicle.Model,
                    LicensePlate = CustomerVehicle.LicensePlate,
                    CustomerId = CustomerVehicle.CustomerId
                };
                var vehicleResult = _vehicleService.Add(vehicle);

                Task.Id = Guid.NewGuid();
                Task.OrderNumber = $"FW{Task.OrderNumber}";
                Task.AssociatedVehicleId = vehicle.Id;
                Task.Notes = "";
                var taskResult = _taskService.Add(Task);
                if (vehicleResult.Succeeded && taskResult.Succeeded)
                {
                    Message = vehicleResult.Message;
                    MessageStatus = MessageStatus.Success;
                    TempData["Message"] = Message;
                    TempData["MessageStatus"] = MessageStatus;
                    return RedirectToPage("/Administration/Vehicle/CustomerVehicles", CustomerVehicle.CustomerId);
                }
                else
                {
                    Message = vehicleResult.Message;
                    MessageStatus = MessageStatus.Failed;
                    TempData["Message"] = Message;
                    TempData["MessageStatus"] = MessageStatus;
                    return RedirectToPage("/Administration/Vehicle/CustomerVehicles", CustomerVehicle.CustomerId);
                }
            }
            else
            {
                Message = $"Validation on the inputs weren't acceptable!";
                MessageStatus = MessageStatus.Failed;
                TempData["Message"] = Message;
                TempData["MessageStatus"] = MessageStatus;
                OnGet(CustomerVehicle.CustomerId.ToString()); ;
                return Page();
            }
        }
    }
}
