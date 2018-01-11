using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MvcMusicStore.Models
{
    public class Album
    {
        public int AlbumID { get; set; }
        [Display(Name = "Albüm Adı")]
        public string Album_Adi { get; set; }
        [Display(Name = "Album Çıkış Tarihi")]
        public DateTime cikis_tarihi { get; set; }
        public virtual ICollection<Kayit> Kayitlar { get; set; }

    }
}