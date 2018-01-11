using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MvcMusicStore.Models
{
    public class Sarki
    {
        public int SarkiID { get; set; }
        [Display(Name = "Şarkı Adı")]
        public string sarki_adi { get; set; }
        [Display(Name = "Şarkı Süresi")]
        public double sarki_suresi { get; set; }
        public string Secret { get; set; }
        public virtual ICollection<Kayit> Kayitlar { get; set; }
        
    }
}