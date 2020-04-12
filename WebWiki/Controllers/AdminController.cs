using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebWiki.Controllers
{
    public class AdminController : Controller
    {
        MyReference.MyWikiServiceClient client = new MyReference.MyWikiServiceClient();
        // GET: Admin
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object o = filterContext.HttpContext.Session["mail"];
            //var actionName = filterContext.RouteData.Values["action"];
            //var ControllerName = filterContext.RouteData.Values["controller"];
            if (o == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "Controller", "Client" }, { "Action", "Index" } });
            }

        }
        public ActionResult Index()
        {
            TempData["new"] = client.LayTTMoiNguoiDung();
            return View();
        }
        #region Category
        public ActionResult Category()
        {
            return View();
        }
        public ActionResult ListCategory()
        {
            TempData["cate"] = client.DSDM();
            return View();
        }
        public ActionResult CreateCategory(MyReference.Danhmuc dm)
        {
            if (client.TaoDM(dm) == true)
            {
                return RedirectToAction("ListCategory");
            }
            return RedirectToAction("Category");
        }
        public ActionResult EditCategory(int MaDM)
        {
            var selectedCate = client.LayDM(MaDM);
            TempData["c"] = new MyReference.Danhmuc { MaDM = selectedCate.MaDM, TenDM = selectedCate.TenDM };
            return View();
        }
        public ActionResult UpdateCate(MyReference.Danhmuc cate)
        {
            if (client.SuaDM(cate) == true)
            {
                return RedirectToAction("ListCategory");
            }
            return RedirectToAction("EditCategory", new { MaDM = cate.MaDM });
        }
        public ActionResult DelCate(int MaDM)
        {
            if (client.XoaDM(MaDM) == true)
            {
                TempData["rs"] = 1;
            }
            else
            {
                TempData["rs"] = 0;
            }
            return RedirectToAction("ListCategory");
        }
        #endregion
        #region Information
        public ActionResult Information()
        {
            TempData["cate"] = client.DSDM();
            return View();
        }
        public ActionResult ListInformation()
        {
            TempData["info"] = client.LayTTNguoiDung();
            return View();
        }
        public ActionResult ListInfoAdmin()
        {
            TempData["ad"] = client.DSTTAdmin();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateInfoByAdmin(MyReference.ThongTin tt)
        {
            try
            {
                tt.AnTT = false;
                tt.MaNguoiDung = 1;
                tt.TTMoi = false;
                if (client.TaoTT(tt) == true)
                {
                    return RedirectToAction("ListInfoAdmin");
                }
            }
            catch (Exception)
            {
                TempData["rs"] = 0;
            }
            return RedirectToAction("Information");
        }
        public ActionResult DetailInfo(int idIF)
        {
            client.DocTTMoi(idIF);
            var model = client.LayTT(idIF);
            TempData["edit"] = client.DSSTT(idIF);
            return View(model);
        }
        public ActionResult DetailInfoAdmin(int idIF)
        {
            client.DocTTMoi(idIF);
            var model = client.LayTT(idIF);
            TempData["edit"] = client.DSSTT(idIF);
            return View(model);
        }
        public ActionResult DetailInfoUser(int idIF)
        {
            client.DocTTMoi(idIF);
            var model = client.LayTT(idIF);
            TempData["edit"] = client.DSSTT(idIF);
            return View(model);
        }
        public ActionResult ActiveAccount(int idUser, int idInfo)
        {
            if (client.KichHoatNguoiDung(idUser)==true)
            {
                TempData["rs"] = 1;
            }
            else
            {
                TempData["rs"] = 0;
            }
            return RedirectToAction("DetailInfo", new { idIF = idInfo });
        }
        public ActionResult HideInfo(int idInfo)
        {
            if (client.AnMotTT(idInfo) == true)
            {
                TempData["rs"] = 2;
            }
            else
            {
                TempData["rs"] = 0;
            }
            return RedirectToAction("DetailInfo", new { idIF = idInfo });
        }
        public ActionResult ShowHideInfoList()
        {
            TempData["info"] = client.LayTTAnAdmin();
            return View();
        }
        public ActionResult ListInfoUserHide()
        {
            TempData["hide"] = client.LayTTAnNguoiDung();
            return View();
        }
        public ActionResult ListInfoUser(int idUser)
        {
            TempData["i"] = client.LayHetTTTheoNguoiDung(idUser);
            return View();
        }
        public ActionResult DetailInfoNormalUser(int idIF)
        {
            client.DocTTMoi(idIF);
            var model = client.LayTT(idIF);
            TempData["edit"] = client.DSSTT(idIF);
            return View(model);
        }
        public ActionResult EditInfo(int idIF)
        {
            var selectedInfo = client.LayTT(idIF);
            TempData["cbb"] = client.LayCBBCate(selectedInfo.MaDM);
            var model = new MyReference.ThongTin_NguoiDung { ChuDeTT = selectedInfo.ChuDeTT, MaDM = selectedInfo.MaDM, NoidungTT = selectedInfo.NoidungTT,TenDM=selectedInfo.TenDM,MaTT=selectedInfo.MaTT};
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateInfo(MyReference.ThongTin i)
        {
            if (client.SuaTT(i) == true)
            {
                var ei = new MyReference.SuaTT { MaNguoiDung = 1, MaTT = i.MaTT, SuaTTMoi = false };
                if (client.TaoSuaTT(ei)==true)
                {
                    return RedirectToAction("ListInfoAdmin");
                }
                
            }
            return RedirectToAction("EditInfo",new { idIF=i.MaTT});
        }
        public ActionResult DelInfo(int idIF)
        {
            if (client.XoaTT(idIF) == true)
            {
                client.XoaSuaTT(idIF);
                TempData["rs"] = 1;
            }
            else
            {
                TempData["rs"] = 0;
            }
            return RedirectToAction("ListInfoAdmin");
        }
        #endregion
        #region Normal User
        public ActionResult NormalUser()
        {
            TempData["user"] = client.LayTatCaNguoiDung();
            return View();
        }
        #endregion
        public ActionResult LogOut()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Client");
        }
        public ActionResult ServiceUser()
        {
            TempData["s"] = client.DSAS();
            return View();
        }
    }
}