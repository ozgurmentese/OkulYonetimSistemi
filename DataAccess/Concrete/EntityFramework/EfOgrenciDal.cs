using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOgrenciDal : EfEntityRepositoryBase<Ogrenci, OkulContext>, IOgrenciDal
    {
        public List<OgrenciOgretmenDto> GetOgrenciOgretmen()
        {
            using (var context = new OkulContext())
            {
                var result = from ogrenciler in context.Ogrenciler
                             join ogretmenler in context.Ogretmenler
                             on ogrenciler.OgretmenId equals ogretmenler.Id
                             select new OgrenciOgretmenDto
                             {
                                 OgrenciId = ogrenciler.Id,
                                 OgrenciAd = ogrenciler.Ad,
                                 OgrenciSoyad = ogrenciler.Soyad,
                                 OgrenciCinsiyet = ogrenciler.Cinsiyet,
                                 OgrenciYas = DateTime.Now.Year - ogrenciler.DogumTarihi.Year,
                                 OgretmenAd = ogretmenler.Ad,
                                 OgretmenSoyad = ogretmenler.Soyad
                             };
                return result.ToList();
            }
        }
    }
}
