using System;
using System.Web.Mvc;

namespace WebWiki.Controllers
{
    public class ClientController : Controller
    {
        private MyReference.MyWikiServiceClient client = new MyReference.MyWikiServiceClient();
        // GET: Client
        public ActionResult Index()
        {
            Session["listCate"] = client.DSDM();
            TempData["random"] = client.LayTTNgauNhien();
            TempData["cate1"] = client.Lay3TT(10);
            TempData["cate2"] = client.Lay3TT(7);
            return View();
        }
        public ActionResult ListInfoByIDCate(int idCate)
        {
            MyReference.Danhmuc model = client.LayDM(idCate);
            TempData["listInfo"] = client.LayTTTheoDM(idCate);
            return View(model);
        }
        public ActionResult InfoDetail(int idInfo)
        {
            MyReference.ThongTin_NguoiDung model = client.LayTT(idInfo);
            if (Session["mail"] != null)
            {
                MyReference.NguoiDung user = client.NguoiDungDangNhap(Convert.ToString(Session["mail"]));
                if (user.MaNguoiDung == model.MaNguoiDung)
                {
                    Session["user"] = 1;
                }
                TempData["id"] = user.MaNguoiDung;
            }
            TempData["cmt"] = client.LayBLNguoiDung(idInfo);
            return View(model);
        }
        public ActionResult FormCreateInfo()
        {
            if (Session["name"] == null)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Hãy đăng nhập hoặc đăng kí để tạo bài viết!');</script>");
            }
            if (Session["service"] != null)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Bạn không có quyền tạo bài viết!');</script>");
            }
            TempData["cate"] = client.DSDM();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateInfoByUser(MyReference.ThongTin tt)
        {
            try
            {
                MyReference.NguoiDung user = client.NguoiDungDangNhap(Convert.ToString(Session["mail"]));
                tt.MaNguoiDung = user.MaNguoiDung;
                tt.AnTT = false;
                tt.TTMoi = true;
                client.TaoTT(tt);
                TempData["success"] = "hihi";
                return RedirectToAction("FormCreateInfo");
            }
            catch (Exception)
            {
                TempData["title"] = tt.ChuDeTT;
                TempData["content"] = tt.NoidungTT;
                TempData["error"] = "huhu";
                return RedirectToAction("FormCreateInfo");
            }
        }
        public ActionResult SignIn(string mail, string pwd)
        {
            if (client.KiemTraNguoiDung(mail, pwd) == 1)
            {
                Session["mail"] = mail;
                return RedirectToAction("Index", "Admin");
            }
            if (client.KiemTraNguoiDung(mail, pwd) == 2)
            {
                MyReference.NguoiDung user = client.NguoiDungDangNhap(mail);
                Session["new"] = client.LayBLMoiTheoNguoiDung(user.MaNguoiDung).Count;
                Session["name"] = user.TenNguoiDung;
                Session["mail"] = user.Mail;
                return RedirectToAction("Index", "Client");
            }
            if (client.KiemTraNguoiDung(mail, pwd) == 3)
            {
                MyReference.NguoiDichVu service = client.NguoiDVDangNhap(mail);
                Session["service"] = service.MailNguoiDV;
                Session["name"] = service.TenNguoiDV;
                return RedirectToAction("Index", "Client");
            }
            return Content("<script language='javascript' type='text/javascript'>alert('Email hoặc mật khẩu đăng nhập không đúng!');</script>");
        }
        public ActionResult InfoUser()
        {
            if (Session["service"] != null)
            {
                return RedirectToAction("InfoService");
            }
            MyReference.NguoiDung user = client.NguoiDungDangNhap(Convert.ToString(Session["mail"]));
            Session["info"] = client.LayTTTheoNguoiDung(user.MaNguoiDung);
            Session["hide"] = client.LayTTAnTheoNguoidung(user.MaNguoiDung);
            TempData["read"] = client.LayBLDaXemTheoNguoiDung(user.MaNguoiDung);
            TempData["new"] = client.LayBLMoiTheoNguoiDung(user.MaNguoiDung);
            return View();
        }
        public ActionResult EditInfo(int idInfo)
        {
            MyReference.ThongTin_NguoiDung model = client.LayTT(idInfo);
            TempData["title"] = model.ChuDeTT;
            TempData["content"] = model.NoidungTT;
            TempData["cate"] = client.LayCBBCate(model.MaDM);
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateInfo(MyReference.ThongTin i)
        {
            try
            {
                if (client.SuaTT(i) == true)
                {
                    MyReference.NguoiDung user = client.NguoiDungDangNhap(Convert.ToString(Session["mail"]));
                    MyReference.SuaTT ei = new MyReference.SuaTT { MaNguoiDung = user.MaNguoiDung, MaTT = i.MaTT, SuaTTMoi = false };
                    client.TaoSuaTT(ei);
                    TempData["success"] = "hihi";
                }
                return RedirectToAction("InfoDetail", new { idInfo = i.MaTT });
            }
            catch (Exception)
            {
                TempData["title"] = i.ChuDeTT;
                TempData["content"] = i.NoidungTT;
                TempData["cate"] = client.LayCBBCate(i.MaDM);
                TempData["error"] = "huhu";
                return RedirectToAction("EditInfo", new { idInfo = i.MaTT });
            }
        }
        public ActionResult HideInfo(int idInfo)
        {
            client.AnMotTT(idInfo);
            return RedirectToAction("InfoUser");
        }
        public ActionResult DelInfo(int idInfo)
        {
            client.XoaTT(idInfo);
            client.XoaSuaTT(idInfo);
            return RedirectToAction("InfoUser");
        }
        public ActionResult SignUp()
        {
            return View();
        }
        public ActionResult CreateUser(MyReference.NguoiDung n)
        {
            if (client.TaoNguoiDung(n) == 0)
            {
                TempData["name"] = n.TenNguoiDung;
                TempData["mail"] = n.Mail;
                TempData["error"] = "huhu";
                return RedirectToAction("SignUp");
            }
            client.TaoNguoiDung(n);
            Session["mail"] = n.Mail;
            Session["name"] = n.TenNguoiDung;
            return RedirectToAction("Index");
        }
        public ActionResult ChangePwd(string pwdOld, string pwdNew)
        {
            MyReference.NguoiDung user = client.NguoiDungDangNhap(Convert.ToString(Session["mail"]));
            if (client.DoiMatKhauNguoiDung(user.MaNguoiDung, pwdOld, pwdNew) == true)
            {
                return RedirectToAction("InfoUser");
            }
            return Content("<script language='javascript' type='text/javascript'>alert('Mật khẩu cũ đăng nhập không đúng!');</script>");
        }
        public ActionResult LogOut()
        {
            Session.RemoveAll();
            return RedirectToAction("Index");
        }
        public ActionResult CreateComment(MyReference.SuaTT cmt)
        {
            if (Session["mail"] == null)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Hãy đăng nhập hoặc đăng kí để viết ý kiến của bạn về bài viết này!');</script>");
            }
            if (Session["service"] != null)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Bạn không có quyền thêm ý kiến cho viết này!');</script>");
            }
            MyReference.NguoiDung user = client.NguoiDungDangNhap(Convert.ToString(Session["mail"]));
            cmt.MaNguoiDung = user.MaNguoiDung;
            cmt.SuaTTMoi = true;
            client.TaoSuaTT(cmt);
            return RedirectToAction("InfoDetail", new { idInfo = cmt.MaTT });
        }
        public ActionResult DelCmt(int idCmt, int idIF)
        {
            client.XoaSuaTTTheoMaSua(idCmt);
            return RedirectToAction("InfoDetail", new { idInfo = idIF });

        }
        public ActionResult ReadCmt(int idEI, int idIF)
        {
            client.DocSuaTTMoi(idEI);
            MyReference.NguoiDung user = client.NguoiDungDangNhap(Convert.ToString(Session["mail"]));
            Session["new"] = client.LayBLMoiTheoNguoiDung(user.MaNguoiDung).Count;
            return RedirectToAction("InfoDetail", new { idInfo = idIF });
        }
        public ActionResult ViewPerson(int idUser, string name)
        {
            ViewBag.name = name;
            TempData["info"] = client.LayTTTheoNguoiDung(idUser);
            return View();
        }
        public ActionResult RegisterService()
        {
            return View();
        }
        public ActionResult CreateAccService(MyReference.NguoiDichVu dv)
        {
            if (client.TaoNguoiDV(dv) == false)
            {
                TempData["name"] = dv.TenNguoiDV;
                TempData["mail"] = dv.MailNguoiDV;
                TempData["error"] = "huhu";
                return RedirectToAction("RegisterService");
            }
            client.TaoNguoiDV(dv);
            Session["service"] = dv.MailNguoiDV;
            Session["name"] = dv.TenNguoiDV;
            return RedirectToAction("Index");

        }
        public ActionResult InfoService()
        {
            var service = client.NguoiDVDangNhap(Convert.ToString(Session["service"]));
            return View(service);
        }
        public JsonResult SearchAjax(string valueSearch)
        {
            var list = client.TimKiemTT(valueSearch);
            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(list), JsonRequestBehavior.AllowGet);
        }
        public ActionResult FormSearchValue(string valueSearch)
        {
            TempData["info"]=client.TTTimKiem(valueSearch);
            ViewBag.name = valueSearch;
            return View();
        }
    }
}