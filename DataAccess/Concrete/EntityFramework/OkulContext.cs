using DataAccess.Concrete.EntityFramework.Mappings;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class OkulContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=OkulYonetimSistemi;Trusted_Connection=true");
        }

        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Ogretmen> Ogretmenler { get; set; }
        public DbSet<Bolum> Bolumler { get; set; }
        public DbSet<DigerPersonel> DigerPersoneller { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OgrenciMap());
            modelBuilder.ApplyConfiguration(new BolumMap());
            modelBuilder.ApplyConfiguration(new DigerPersonelMap());
            modelBuilder.ApplyConfiguration(new OgretmenMap());
        }
    }
}
