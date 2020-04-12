using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPartner.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            PartnerReference.ServicePartnerClient cl = new PartnerReference.ServicePartnerClient();
            var info = cl.LayTT("l6t0jhnDVE+N68kgaoclSQ==", "cfjndsnaidj219u");
            return View();
        }
    }
}
