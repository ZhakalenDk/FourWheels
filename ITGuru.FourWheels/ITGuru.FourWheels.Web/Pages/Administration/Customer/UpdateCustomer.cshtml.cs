using ITGuru.FourWheels.Service;
using ITGuru.FourWheels.Web.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITGuru.FourWheels.Web.Pages.Administration.Customer
{
    public class UpdateCustomerModel : PageModel
    {
        public UpdateCustomerModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        private readonly ICustomerService _customerService;

        [BindProperty]
        public CustomerDTO Customer { get; set; }

        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public MessageStatus MessageStatus { get; set; }

        public void OnGet(string CustomerId)
        {
            Customer = _customerService.GetById(new Guid(CustomerId)) as CustomerDTO;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Customer != null)
                {
                    var result = _customerService.Update(Customer);
                    if (result.Succeeded)
                    {
                        Message = $"Successfully updated the customer: {Customer.FirstName} {Customer.LastName}";
                        MessageStatus = MessageStatus.Success;
                        TempData["Message"] = Message;
                        TempData["MessageStatus"] = MessageStatus;
                        return RedirectToPage("/Administration/SearchPage");
                    }
                    else
                    {
                        Message = $"Couldn't update the customer.";
                        MessageStatus = MessageStatus.Failed;
                        TempData["Message"] = Message;
                        TempData["MessageStatus"] = MessageStatus;
                        return RedirectToPage("/Administration/SearchPage");
                    }
                }
                return RedirectToPage("/Administration/SearchPage");
            }
            else
            {
                return Page();
            }
        }
    }
}
