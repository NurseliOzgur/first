using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcMusicStore.Models;
using System.Data.Entity;
namespace MvcMusicStore.DAL
{
    public class SarkiInitializer :System.Data.Entity.DropCreateDatabaseIfModelChanges<SarkiContext>
    {
        protected override void Seed(SarkiContext context)
        {
            var Sarkilar = new List<Sarki> 
            {
                new Sarki{sarki_adi="Shy",sarki_suresi=3.58},
                new Sarki{sarki_adi="Rusted Nail" , sarki_suresi=4.56},
                new Sarki{sarki_adi="Medcezir",sarki_suresi=4.58},
                new Sarki{sarki_adi="Baby I'm gonna Leave You",sarki_suresi=6.38},
                new Sarki{sarki_adi="Broken",sarki_suresi=3.58},
                new Sarki{sarki_adi="KaraDuman",sarki_suresi=4.16},
                new Sarki{sarki_adi="By the Way",sarki_suresi=1.54},
                new Sarki{sarki_adi="Dosed",sarki_suresi=3.32},
                new Sarki{sarki_adi="Don't Forget Me ",sarki_suresi=4.08},
                new Sarki{sarki_adi="Can't Stop",sarki_suresi=3.38}
            };
            Sarkilar.ForEach(s => context.Sarkilar.Add(s));
            context.SaveChanges();

            var Albumler = new List<Album>
            {
                new Album{Album_Adi="In Flames",cikis_tarihi=DateTime.Parse("1992-09-01")},
                new Album{Album_Adi="Countdown to Extinction",cikis_tarihi=DateTime.Parse("1992-09-01")},
                new Album{Album_Adi="The Best Damn Thing",cikis_tarihi=DateTime.Parse("2007-09-01")},
                new Album{Album_Adi="Death Magnetic",cikis_tarihi=DateTime.Parse("2008-09-01")},
                new Album{Album_Adi="All The Right Reasons",cikis_tarihi=DateTime.Parse("2005-09-01")},
                new Album{Album_Adi="Chinese Democracy",cikis_tarihi=DateTime.Parse("2008-09-01")},
                new Album{Album_Adi="A Rush Of Blood To the Head",cikis_tarihi=DateTime.Parse("2002-09-01")},
                new Album{Album_Adi="Load",cikis_tarihi=DateTime.Parse("1996-09-01")},
                new Album{Album_Adi="Goodbye Lullaby",cikis_tarihi=DateTime.Parse("2011-09-01")}

                
            };
            Albumler.ForEach(s => context.Albumler.Add(s));
            context.SaveChanges();

            var kayitlar = new List<Kayit> 
            {
                new Kayit{KayitID=1,AlbumID=1,SarkiID=1},
                new Kayit{KayitID=2,AlbumID=1,SarkiID=2},
                new Kayit{KayitID=3,AlbumID=3,SarkiID=3},
                new Kayit{KayitID=4,AlbumID=4,SarkiID=4},
                new Kayit{KayitID=5,AlbumID=5,SarkiID=5},
                new Kayit{KayitID=6,AlbumID=6,SarkiID=6},
                new Kayit{KayitID=7,AlbumID=7,SarkiID=7},
                new Kayit{KayitID=8,AlbumID=8,SarkiID=8},
                new Kayit{KayitID=9,AlbumID=9,SarkiID=9},
            };
            kayitlar.ForEach(s => context.Kayitlar.Add(s));
            context.SaveChanges();
        
        }
    }
}