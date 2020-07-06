using GapPolicyBUSINESS;
using GapPolicyDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GapPolicy.Controllers
{
    public class LoginController : Controller
    {
        LoginBusiness bus = new LoginBusiness();
        // GET: Login
        public ActionResult Index(string message=null)
        {
            ViewBag.Message = message;
            return View();
        }

        public ActionResult Validate(Login login)
        {

            Login credentials;
            if (!string.IsNullOrEmpty(login.Identification) && !string.IsNullOrEmpty(login.Password))
            {
                credentials = bus.GetCredentials(login).FirstOrDefault();
                if (credentials != null)
                {
                    FormsAuthentication.SetAuthCookie(credentials.Identification, true);                   
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", new { message = "User not exist." });
                }
            }
            else
            {
                return RedirectToAction("Index", new { message = "Credential is empty." });
            }
        }

        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}