using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class OgrenciMap : IEntityTypeConfiguration<Ogrenci>
    {
        public void Configure(EntityTypeBuilder<Ogrenci> builder)
        {
            builder.ToTable(@"Ogrenciler", "dbo");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.Ad).HasColumnName("Ad");
            builder.Property(e => e.Soyad).HasColumnName("Soyad");
            builder.Property(e => e.Cinsiyet).HasColumnName("Cinsiyet");
            builder.Property(e => e.DogumTarihi).HasColumnName("DogumTarihi");
            builder.Property(e => e.OgretmenId).HasColumnName("OgretmenId");
            builder.Property(e => e.BolumId).HasColumnName("BolumId");
        }
    } 
}
