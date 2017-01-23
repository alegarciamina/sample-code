using System.Web.Mvc;
using UT.Presentation.Web.Constants;

namespace UT.Presentation.Web.Controllers
{
    public class LoginController: Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if (Session[SessionKeys.CustomerNumber] != null)
                return Redirect("/");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(int customerNumber)
        {
            //Simulate signin
            Session[SessionKeys.CustomerNumber] = customerNumber;
            return Redirect("/");
        }

        public ActionResult Logout()
        {
            //Simulate signout
            Session[SessionKeys.CustomerNumber] = null;
            return Redirect("/");
        }

        
    }
}