using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MvcMusicStore.Models;
namespace MvcMusicStore.DAL
{
    public class SarkiContext : DbContext
    {
        public SarkiContext() : base("SarkiContext")
        {
        }
        public DbSet<Sarki> Sarkilar { get; set; }
        public DbSet<Kayit> Kayitlar { get; set; }
        public DbSet<Album> Albumler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}