using System.Web.Mvc;
using web.Models;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new CalendarViewModel());
        }
    }
}