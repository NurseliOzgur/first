using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMusicStore.Models
{
    public class Kayit
    {
        public int KayitID { get; set; }
        public int AlbumID { get; set; }
        public int SarkiID { get; set; }
        public virtual Sarki Sarki { get; set; }
        public virtual Album Album { get; set; }
    }
}