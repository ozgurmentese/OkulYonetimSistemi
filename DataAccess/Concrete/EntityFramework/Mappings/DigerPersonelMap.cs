using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class DigerPersonelMap : IEntityTypeConfiguration<DigerPersonel>
    {
        public void Configure(EntityTypeBuilder<DigerPersonel> builder)
        {
            builder.ToTable(@"DigerPersoneller", "dbo");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.Ad).HasColumnName("Ad");
            builder.Property(e => e.Soyad).HasColumnName("Soyad");
            builder.Property(e => e.Cinsiyet).HasColumnName("Cinsiyet");
            builder.Property(e => e.DogumTarihi).HasColumnName("DogumTarihi");
            builder.Property(e => e.BolumId).HasColumnName("BolumId");
        }
    }    
}
