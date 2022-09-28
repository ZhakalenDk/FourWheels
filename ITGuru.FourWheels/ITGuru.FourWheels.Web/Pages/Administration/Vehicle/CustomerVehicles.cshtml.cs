using ITGuru.FourWheels.Data.DataModels;
using ITGuru.FourWheels.Service;
using ITGuru.FourWheels.Web.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITGuru.FourWheels.Web.Pages.Administration.Vehicle
{
    public class CustomerVehiclesModel : PageModel
    {
        private readonly ICustomerService _customerService;
        private readonly IVehicleService _vehicleService;
        public CustomerVehiclesModel(ICustomerService customerService, IVehicleService vehicleService)
        {
            _customerService = customerService;
            _vehicleService = vehicleService;
        }

        [BindProperty]
        public IReadOnlyList<IVehicle> Vehicles { get; set; }

        [BindProperty]
        public CustomerDTO Customer { get; set; }

        [BindProperty]
        public VehicleDTO Vehicle { get; set; }

        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public MessageStatus MessageStatus { get; set; }

        public void OnGet(string CustomerId)
        {
            Customer = _customerService.GetById(new Guid(CustomerId)) as CustomerDTO;
            Vehicles = Customer.GetVehicles();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Vehicle.Id = Guid.NewGuid();
                Vehicle.CustomerId = Customer.Id;
                var vehicleResult = _vehicleService.Add(Vehicle);
                if (vehicleResult.Succeeded)
                {
                    Message = vehicleResult.Message;
                    MessageStatus = MessageStatus.Success;
                    TempData["Message"] = Message;
                    TempData["MessageStatus"] = MessageStatus;
                    return RedirectToPage("/Administration/Vehicle/CustomerVehicles", Vehicle.CustomerId);
                }
                else
                {
                    Message = vehicleResult.Message;
                    MessageStatus = MessageStatus.Failed;
                    TempData["Message"] = Message;
                    TempData["MessageStatus"] = MessageStatus;
                    return RedirectToPage("/Administration/Vehicle/CustomerVehicles", Vehicle.CustomerId);
                }
            }
            else
            {
                Message = $"Validation on the inputs weren't acceptable!";
                MessageStatus = MessageStatus.Failed;
                TempData["Message"] = Message;
                TempData["MessageStatus"] = MessageStatus;
                OnGet(Customer.Id.ToString()); ;
                return Page();
            }
        }
    }
}
