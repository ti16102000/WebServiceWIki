using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFishPartner.Models;

namespace WebFishPartner.Controllers
{
    public class PartnerController : Controller
    {
        PartnerReference.WebPartnerClient cl = new PartnerReference.WebPartnerClient();
        // GET: Partner
        public ActionResult Index()
        {
            List<Fish> ls = new List<Fish>
            {
                new Fish{ id=1,name="Cá nóc chuột vân bụng",import="BR-VT",price="1000USD/con",token="rRNZTETTrEKSvrzILKNiZg=="},
                new Fish{ id=2,name="Cá đuối ó",import="LA",price="2000USD/con",token="abc123xyzhihi"},
                new Fish{ id=3,name="Cá thát lát",import="Daklak",price="2000VND/con",token="XxKpb+2NLECbrN+IbBfqXw=="}
            };
            Session["f"] = ls;
            return View();
        }
        public ActionResult FishDetail(int id)
        {
            List<Fish> ls = new List<Fish>();
            ls = Session["f"] as List<Fish>;
            var fish = ls.SingleOrDefault(s => s.id == id);
            TempData["f"] = fish;
            var model = cl.LayTT("74bm3yO9ik6OMsADClmTZw==", fish.token);
            return View(model);
        }
    }
}