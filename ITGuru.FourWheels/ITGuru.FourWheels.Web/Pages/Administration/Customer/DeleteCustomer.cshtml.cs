using ITGuru.FourWheels.Service;
using ITGuru.FourWheels.Web.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITGuru.FourWheels.Web.Pages.Administration.Customer
{
    public class DeleteCustomerModel : PageModel
    {
        private readonly ICustomerService _customerService;
        public DeleteCustomerModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [BindProperty]
        public CustomerDTO Customer { get; set; }

        public void OnGet(string CustomerId)
        {
            Customer = _customerService.GetById(new Guid(CustomerId)) as CustomerDTO;
        }

        public IActionResult OnPost()
        {
            if (_customerService.Remove(Customer).Succeeded)
            {
                TempData["Message"] = $"Successfully delete the customer {Customer.FirstName} {Customer.LastName}";
                TempData["MessageStatus"] = MessageStatus.Success;
                return RedirectToPage("/Administration/SearchPage");
            }
            else
            {
                TempData["Message"] = $"Couldn't delete customer {Customer.FirstName} {Customer.LastName}";
                TempData["MessageStatus"] = MessageStatus.Failed;
                return RedirectToPage("/Administration/SearchPage");
            }
        }
    }
}
