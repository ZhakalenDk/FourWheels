using ITGuru.FourWheels.Service;
using ITGuru.FourWheels.Web.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITGuru.FourWheels.Web.Pages.Administration
{
    public class SearchPageModel : PageModel
    {
        private readonly ICustomerService _customerService;

        [BindProperty]
        public IReadOnlyList<ICustomer> Customers { get; set; }

        [BindProperty]
        public CustomerDTO Customer { get; set; }

        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public MessageStatus MessageStatus { get; set; }

        public SearchPageModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

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
                var result = _customerService.Add(Customer);
                if (result.Succeeded)
                {
                    Message = $"Successfully created a new customer!";
                    MessageStatus = MessageStatus.Success;
                    TempData["Message"] = Message;
                    TempData["MessageStatus"] = MessageStatus;
                    return RedirectToPage("/Administration/SearchPage");
                }
                else
                {
                    Message = $"There was a mistake trying to add a customer: {result.Message}";
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

        public IActionResult OnPostUpdateCustomer()
        {
            if (ModelState.IsValid)
            {
                if (Customer != null)
                {
                    _customerService.Update(Customer);
                    Message = $"Successfully updated the customer: {Customer.FirstName} {Customer.LastName}";
                    MessageStatus = MessageStatus.Success;
                    TempData["Message"] = Message;
                    TempData["MessageStatus"] = MessageStatus;
                    return RedirectToPage("/Administration/SearchPage");
                }
                else
                {
                    return Page();
                }
            }
            else
            {
                Message = $"Couldn't update customer: {Customer.FirstName} {Customer.LastName}";
                MessageStatus = MessageStatus.Failed;
                TempData["Message"] = Message;
                TempData["MessageStatus"] = MessageStatus;
                OnGet();
                return Page();
            }
        }

        public void OnPostDeleteCustomer()
        {
            //TODO: Delete Customer
        }
    }
}
