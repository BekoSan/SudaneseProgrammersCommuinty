using SudaneseProgComLibrary.APIProcessors;
using SudaneseProgComLibrary.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SudaneseProgrammersCommuintyWebApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            //ApiHelper.InitializeClient();

            ViewBag.Title = "Home Page";
            var Members = await MembersProcessor.LoadAllMembers();
            return View(Members);
        }

        [Route("members/profile/{id}")]
        [HttpGet]
        public async Task<ActionResult> Profile(int Id)
        {
            ViewBag.Title = "Member Profile";
            var Member = await MembersProcessor.LoadMemberProfile(Id);
            return View(Member);
        }

        public async Task<ActionResult> Edit(int Id)
        {
            ViewBag.Title = "Edit Member";
            var Member = await MembersProcessor.LoadMemberProfile(Id);

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
            ViewBag.Title = "New Member";
            return View("MemberForm");
        }

        public async Task<ActionResult> Delete(bool accept, int Id)
        {
            if (accept)
            {
                await MembersProcessor.DeleteMember(Id);
            }
            return RedirectToAction("Index", await MembersProcessor.LoadAllMembers());
        }

        [Route("members/save")]
        [HttpPost]
        public async Task<ActionResult> Save(Member member)
        {
            if (member.Id == 0)
            {
                await MembersProcessor.CreateMember(member);
            }
            else
            {
                //memControler.Put(member.Id, member);
                await MembersProcessor.UpdateMember(member.Id, member);
            }
            return RedirectToAction("Index", await MembersProcessor.LoadAllMembers());
        }
    }
}