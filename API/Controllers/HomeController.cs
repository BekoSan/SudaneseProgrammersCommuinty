using System.Linq;
using System.Web.Mvc;

namespace API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            var Members = new MembersController().Get().ToList();
            return View(Members);
        }
    }
}