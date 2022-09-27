using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITGuru.FourWheels.Web.Pages.Administration
{
    public class SearchPageModel : PageModel
    {
        //Ready for Customer object implementation.
        public List<object> Customers { get; set; }

        public void OnGet()
        {
            //TODO: Get all Customer
        }

        public void OnPostCreateCustomer()
        {
            //TODO: Create new Customer
        }

        public void OnPostUpdateCustomer()
        {
            //TODO: Update Customer
        }

        public void OnPostDeleteCustomer()
        {
            //TODO: Delete Customer
        }
    }
}
