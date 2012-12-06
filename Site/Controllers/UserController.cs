using System.Web.Mvc;
using Site.Models;

namespace Site.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserForm userForm)
        {
            return View(userForm);
        }
    }
}
