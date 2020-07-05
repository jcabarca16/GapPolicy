using GapPolicyBUSINESS;
using GapPolicyDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GapPolicy.Controllers
{
    [Authorize]
    public class PolicyController : Controller
    {
        PolicyBusiness policytBus = new PolicyBusiness();
        // GET: Policy
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetPolicy()
        {
            return Json(policytBus.GetPolicy(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeletePolicy(int Id)
        {
            return Json(policytBus.DeletePolicy(Id));
        }

        [HttpPost]
        public ActionResult InsertPolicy(Policy policy)
        {
            return Json(policytBus.InsertPolicy(policy));
        }

        [HttpPost]
        public ActionResult UpdatePolicy(Policy policy)
        {
            return Json(policytBus.UpdatePolicy(policy));
        }

        [HttpGet]
        public ActionResult GetPolicyId(string Id)
        {
            return Json(policytBus.GetPolicyId(Id), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetPolicyType()
        {
            return Json(policytBus.GetPolicyTypes(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetClients()
        {
            return Json(policytBus.GetClients(), JsonRequestBehavior.AllowGet);
        }
    }
}