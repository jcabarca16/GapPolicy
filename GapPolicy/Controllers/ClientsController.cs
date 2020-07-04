using GapPolicyBUSINESS;
using GapPolicyDAO;
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
            return Json(clientBus.GetClients(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteClients(string Identification)
        {
            return Json(clientBus.DeleteClients(Identification));
        }
        public ActionResult InsertClients(Client client)
        {
            return Json(clientBus.InsertClients(client));
        }
        public ActionResult UpdateClients(Client client)
        {
            return Json(clientBus.UpdateClients(client));
        }
        public ActionResult GetClientsIdentification(string Identification)
        {
            return Json(clientBus.GetClientIdentification(Identification));
        }
    }
}