using GapPolicyBUSINESS;
using GapPolicyDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GapPolicy.Controllers
{
    public class PolicyController : Controller
    {
        PolicyBusiness policytBus = new PolicyBusiness();
        // GET: Policy
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetPolicy()
        {
            return Json(policytBus.GetPolicy(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeletePolicy(int Id)
        {
            return Json(policytBus.DeletePolicy(Id));
        }
        public ActionResult InsertPolicy(Policy policy)
        {
            return Json(policytBus.InsertPolicy(policy));
        }
        public ActionResult UpdatePolicy(Policy policy)
        {
            return Json(policytBus.UpdatePolicy(policy));
        }
        public ActionResult GetPolicyId(string Id)
        {
            return Json(policytBus.GetPolicyId(Id), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetPolicyType()
        {
            return Json(policytBus.GetPolicyTypes(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetClients()
        {
            return Json(policytBus.GetClients(), JsonRequestBehavior.AllowGet);
        }
    }
}