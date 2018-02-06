using MyCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCommerce.ViewModel
{
    public class Sepet
    {
        public static Sepet AktifMi
        {
            get
            {
                HttpContext httpContext = HttpContext.Current;
                if (httpContext.Session["sepettemi"] == null)
                {
                    httpContext.Session["sepettemi"] = new Sepet();
                }
                return httpContext.Session["sepettemi"] as Sepet;
            }
        }



        public List<SepetUrunler> urunler = new List<SepetUrunler>();

        public void SepetEkle(SepetUrunler sp)
        {
            if (HttpContext.Current.Session["sepettemi"] != null)
            {
                Sepet sepet = HttpContext.Current.Session["sepettemi"] as Sepet;

                if (sepet.urunler.Any(x => x.urun.UrunID == sp.urun.UrunID))
                {
                    sepet.urunler.FirstOrDefault(x => x.urun.UrunID == sp.urun.UrunID).Adet++;
                }
                else
                {
                    sepet.urunler.Add(sp);
                }

            }
            else
            {
                Sepet sepet = new Sepet();
                sepet.urunler.Add(sp);
                HttpContext.Current.Session["sepettemi"] = sepet;
            }
        }

        public decimal GenelToplam
        {
            get
            {
                return urunler.Sum(x => x.Tutar);
            }
        }
    }

    public class SepetUrunler
    {
        public Urunler urun { get; set; }
        public int Adet { get; set; }
        public decimal Tutar
        {
            get
            {
                return Adet * (decimal)urun.BirimFiyati;
            }
        }


    }
}