using ITGuru.FourWheels.Service;
using ITGuru.FourWheels.Web.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITGuru.FourWheels.Web.Pages.Administration.Vehicle
{
    public class DeleteVehicleModel : PageModel
    {
        private readonly IVehicleService _vehicleService;
        public DeleteVehicleModel(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [BindProperty]
        public VehicleDTO Vehicle { get; set; }

        public void OnGet(string vehicleId)
        {
            Vehicle = _vehicleService.GetById(new Guid(vehicleId)) as VehicleDTO;
        }

        public IActionResult OnPost()
        {
            if (_vehicleService.Remove(Vehicle).Succeeded)
            {
                TempData["Message"] = $"Successfully delete the vehicle {Vehicle.Brand} {Vehicle.Model}";
                TempData["MessageStatus"] = MessageStatus.Success;
                return RedirectToPage("/Administration/Vehicle/CustomerVehicles", Vehicle.CustomerId);
            }
            else
            {
                TempData["Message"] = $"Couldn't delete vehicle {Vehicle.Brand} {Vehicle.Model}";
                TempData["MessageStatus"] = MessageStatus.Failed;
                return RedirectToPage("/Administration/Vehicle/CustomerVehicles", Vehicle.CustomerId);
            }
        }
    }
}
