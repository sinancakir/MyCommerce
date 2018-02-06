using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCommerce.Models;
using MyCommerce.App_Start;
using static MyCommerce.ViewModel.Sepet;
using MyCommerce.ViewModel;

namespace MyCommerce.Controllers
{
    [KullaniciFilter]
    public class UrunController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        // GET: Urun
        public ActionResult Detay(int id)
        {

            //int id = Convert.ToInt32(UrunID);
            Urunler urn = db.Urunler.Find(id);
            ViewBag.Detay = urn.UrunAdi.ToString();
            return View(urn);
        }


        [HttpPost]
        public void SepetEkle(int id)
        {
            SepetUrunler sepetUrunler = new SepetUrunler();

            Urunler urunnn = db.Urunler.Find(id);

            sepetUrunler.urun = urunnn;
            sepetUrunler.Adet = 1;


            Sepet sepet = new Sepet();
            sepet.SepetEkle(sepetUrunler);

        }

        public ActionResult Sepet()
        {
            if (HttpContext.Session["sepettemi"] != null)
            {
                return View(HttpContext.Session["sepettemi"] as Sepet);
            }
            else
            {
                return View();
            }

        }
    }
}