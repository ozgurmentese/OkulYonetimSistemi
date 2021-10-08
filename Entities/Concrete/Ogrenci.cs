using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Ogrenci : IEntity
    {
        public int Id { get; set; }
        public int OgretmenId { get; set; }
        public int BolumId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public char Cinsiyet { get; set; }
    }
}
