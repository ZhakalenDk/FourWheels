using ITGuru.FourWheels.Web.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITGuru.FourWheels.Web.Pages.Administration.Tasks
{
    public class VehicleTasksModel : PageModel
    {
        //TODO: Uncomment when ITask interface is done
        //[BindProperty]
        //public IReadOnlyList<ITask> Tasks { get; set; }

        [BindProperty]
        public string Message { get; set; }

        [BindProperty]
        public MessageStatus MessageStatus { get; set; }

        public void OnGet(string VehicleId)
        {

        }
    }
}
