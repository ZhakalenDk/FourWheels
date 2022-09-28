using ITGuru.FourWheels.Service;
using ITGuru.FourWheels.Web.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITGuru.FourWheels.Web.Pages.Administration.Vehicle
{
    public class UpdateVehicleModel : PageModel
    {
        public UpdateVehicleModel(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        private readonly IVehicleService _vehicleService;

        [BindProperty]
        public VehicleDTO Vehicle { get; set; }

        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public MessageStatus MessageStatus { get; set; }

        public void OnGet(string VehicleId)
        {
            Vehicle = _vehicleService.GetById(new Guid(VehicleId)) as VehicleDTO;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Vehicle != null)
                {
                    var result = _vehicleService.Update(Vehicle);
                    if (result.Succeeded)
                    {
                        Message = result.Message;
                        MessageStatus = MessageStatus.Success;
                        TempData["Message"] = Message;
                        TempData["MessageStatus"] = MessageStatus;
                        return RedirectToPage("/Administration/Vehicle/CustomerVehicles", Vehicle.CustomerId);
                    }
                    else
                    {
                        Message = result.Message;
                        MessageStatus = MessageStatus.Failed;
                        TempData["Message"] = Message;
                        TempData["MessageStatus"] = MessageStatus;
                        return RedirectToPage("/Administration/Vehicle/CustomerVehicles", Vehicle.CustomerId);
                    }
                }
                return RedirectToPage("/Administration/Vehicle/CustomerVehicles", Vehicle.CustomerId);
            }
            else
            {
                return Page();
            }
        }
    }
}
