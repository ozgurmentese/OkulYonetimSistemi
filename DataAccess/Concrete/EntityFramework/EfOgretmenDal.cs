using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOgretmenDal : EfEntityRepositoryBase<Ogretmen, OkulContext>, IOgretmenDal
    {
        public List<OgretmenOgrenciSayisiDto> OgretmenOgrenciSayisi()
        {
            using (var context = new OkulContext())
            {
                var result = from ogrenciler in context.Ogrenciler
                             join ogretmenler in context.Ogretmenler
                             on ogrenciler.OgretmenId equals ogretmenler.Id
                             group ogretmenler by new
                             {
                                 ogretmenler.Id,
                                 ogretmenler.Ad,
                                 ogretmenler.Soyad,
                                 ogretmenler.DogumTarihi,
                                 ogretmenler.Cinsiyet
                             } into grup
                             select new OgretmenOgrenciSayisiDto
                             {
                                 OgretmenId = grup.Key.Id,
                                 OgretmenAd = grup.Key.Ad,
                                 OgretmenSoyad = grup.Key.Soyad,
                                 Cinsiyet = grup.Key.Cinsiyet,
                                 Yas = DateTime.Now.Year - grup.Key.DogumTarihi.Year,
                                 OgrenciSayisi = grup.Count()
                             };
                return result.ToList();
            }
        }

    }
}
