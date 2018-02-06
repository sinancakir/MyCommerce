using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyCommerce.ViewModel
{
    public class UserViewModel
    {
        [StringLength(30),MaxLength(30,ErrorMessage ="Lütfen {1} Karakteri Geçmeyiniz"),Display(Name ="Kullanıcı Adı:")]
        public string KullaniciAdi { get; set; }
        [StringLength(30), MaxLength(30, ErrorMessage = "Lütfen {1} Karakteri Geçmeyiniz"), Display(Name = "Parola :")]
        public string Parola { get; set; }
    }
}