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
        public CustomerVehiclesModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [BindProperty]
        public IReadOnlyList<IVehicle> Vehicles { get; set; }

        [BindProperty]
        public ICustomer Customer { get; set; }

        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public MessageStatus MessageStatus { get; set; }

        public void OnGet(string CustomerId)
        {
            Customer = _customerService.GetById(new Guid(CustomerId)) as CustomerDTO;
            Vehicles = Customer.GetVehicles();
        }
    }
}
