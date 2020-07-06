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
    public class PolicyTypeController : Controller
    {

        PolicyTypeBusiness policyBus = new PolicyTypeBusiness();
        // GET: PolicyType
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetPolicyType()
        {
            return Json(policyBus.GetPolicyType(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeletePolicyType(int Id)
        {
            return Json(policyBus.DeletePolicyType(Id));
        }

        [HttpPost]
        public ActionResult InsertPolicyType(PolicyCatalog policy)
        {
            policy.ModificationUser = User.Identity.Name;
            return Json(policyBus.InsertPolicyType(policy));
        }

        [HttpPost]
        public ActionResult UpdatePolicyType(PolicyCatalog policy)
        {
            policy.ModificationUser = User.Identity.Name;
            return Json(policyBus.UpdatePolicyType(policy));
        }

        [HttpGet]
        public ActionResult GetPolicyTypeIdentification(int Id)
        {
            return Json(policyBus.GetPolicyTypeId(Id), JsonRequestBehavior.AllowGet);
        }
    }
}