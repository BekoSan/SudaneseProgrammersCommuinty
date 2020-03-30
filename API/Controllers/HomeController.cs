using SudaneseProgComLibrary.Models;
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

        [Route("members/profile/{id}")]
        [HttpGet]
        public ActionResult Profile(int Id)
        {
            ViewBag.Title = "Member Profile";
            var Member = new MembersController().LoadMemberProfile(Id);
            return View(Member);
        }

        public ActionResult Edit(int Id)
        {
            ViewBag.Title = "Edit Member";
            var Member = new MembersController().LoadMemberProfile(Id);

            if (Member.Id == 0)
            {
                return HttpNotFound();
            }
            else
            {
                return View("MemberForm", Member);
            }
        }

        public ActionResult New()
        {
            return View("MemberForm");
        }

        [HttpPost]
        public ActionResult Delete(bool accept, int Id)
        {
            var memControler = new MembersController();
            if (accept)
            {
                memControler.Delete(Id);
            }
            return RedirectToAction("Index", memControler.Get().ToList());
        }

        [Route("members/save")]
        [HttpPost]
        public ActionResult Save(Member member)
        {
            var memControler = new MembersController();
            if (member.Id == 0)
            {
                memControler.Post(member);
            }
            else
            {
                memControler.Put(member.Id, member);
            }
            return RedirectToAction("Index", memControler.Get().ToList());
        }
    }
}