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
    [Authorize]
    public class ClientsController : Controller
    {
        ClientBusiness clientBus = new ClientBusiness();
        // GET: Clients
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetClients()
        {
            return Json(clientBus.GetClients(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteClients(string Identification)
        {
            return Json(clientBus.DeleteClients(Identification));
        }

        [HttpPost]
        public ActionResult InsertClients(Client client)
        {
            client.ModificationUser = User.Identity.Name;
            return Json(clientBus.InsertClients(client));
        }

        [HttpPost]
        public ActionResult UpdateClients(Client client)
        {
            client.ModificationUser = User.Identity.Name;
            return Json(clientBus.UpdateClients(client));
        }

        [HttpGet]
        public ActionResult GetClientsIdentification(string Identification)
        {
            return Json(clientBus.GetClientIdentification(Identification), JsonRequestBehavior.AllowGet);
        }
    }
}