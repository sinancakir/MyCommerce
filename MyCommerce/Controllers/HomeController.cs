using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCommerce.Models;
using MyCommerce.ViewModel;
using MyCommerce.App_Start;

namespace MyCommerce.Controllers
{

    public class HomeController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        // GET: Home
        [KullaniciFilter]
        public ActionResult Index()
        {
            return View();
        }
        [KullaniciFilter]
        public PartialViewResult GetProducts()
        {
            List<Urunler> urunler= db.Urunler.Where(x => x.Sonlandi == false).Take(6).ToList();
            return PartialView("_UrunlerPartial",urunler);
        }

        public ActionResult LogIn()
        {

            return View();
        }
        [HttpPost]
        public ActionResult LogIn(UserViewModel model)
        {
            SiteUsers user = db.SiteUsers.FirstOrDefault(y => y.Kadi == model.KullaniciAdi && y.Pass == model.Parola);
            if(user==null)
            {
                ModelState.AddModelError("", "Lütfen Geçerli Kullanıcı Adı Giriniz!");
                return View();
            }

            Session["user"] = user;


            return View("Index");
        }

        public ActionResult LogOut()
        {
            if(Session["user"]!=null)
            Session["user"] = null;
            return RedirectToAction("LogIn");
        }
    }
}