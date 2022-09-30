using ITGuru.FourWheels.Service;
using ITGuru.FourWheels.Web.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITGuru.FourWheels.Web.Pages.Administration
{
    public class SearchPageModel : PageModel
    {
        public SearchPageModel(ICustomerService customerService, IVehicleService vehicleService, ITaskService taskService)
        {
            _customerService = customerService;
            _vehicleService = vehicleService;
            _taskService = taskService;
        }

        private readonly ICustomerService _customerService;
        private readonly IVehicleService _vehicleService;
        private readonly ITaskService _taskService;

        [BindProperty]
        public IReadOnlyList<ICustomer> Customers { get; set; }

        [BindProperty]
        public CustomerDTO Customer { get; set; }
        [BindProperty]
        public VehicleDTO Vehicle { get; set; }
        [BindProperty]
        public TaskDTO Task { get; set; }

        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public MessageStatus MessageStatus { get; set; }

        [BindProperty]
        public bool ShowTaskCreation { get; set; }

        public void OnGet()
        {
            Customers = _customerService.GetAll();
        }

        public IActionResult OnPostCreateCustomer()
        {
            if (ModelState.IsValid)
            {
                Customer.Id = Guid.NewGuid();
                Customer.Phone = Customer.Phone.Replace(" ", string.Empty);
                var customerResult = _customerService.Add(Customer);

                Vehicle.Id = Guid.NewGuid();
                Vehicle.CustomerId = Customer.Id;
                var vehicleResult = _vehicleService.Add(Vehicle);

                Task.Id = Guid.NewGuid();
                Task.OrderNumber = $"FW{Task.OrderNumber}";
                Task.AssociatedVehicleId = Vehicle.Id;
                var taskResult = _taskService.Add(Task);
                if (customerResult.Succeeded && vehicleResult.Succeeded && taskResult.Succeeded)
                {
                    Message = $"Successfully created a new customer with a vehicle and a task!";
                    MessageStatus = MessageStatus.Success;
                    TempData["Message"] = Message;
                    TempData["MessageStatus"] = MessageStatus;
                    return RedirectToPage("/Administration/SearchPage");
                }
                else
                {
                    Message = $"There was a mistake trying to add a customer with their vehicle and a task.";
                    MessageStatus = MessageStatus.Failed;
                    TempData["Message"] = Message;
                    TempData["MessageStatus"] = MessageStatus;
                    return RedirectToPage("/Administration/SearchPage");
                }
            }
            else
            {
                Message = $"Validation on the inputs weren't acceptable!";
                MessageStatus = MessageStatus.Failed;
                TempData["Message"] = Message;
                TempData["MessageStatus"] = MessageStatus;
                OnGet();
                return Page();
            }
        }
    }
}
