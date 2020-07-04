using GapPolicyBUSINESS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GapPolicy.Controllers
{
    public class ClientsController : Controller
    {
        ClientBusiness clientBus = new ClientBusiness();
        // GET: Clients
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetClients()
        {
            return Json(clientBus.getClients(), JsonRequestBehavior.AllowGet);
        }
    }
}