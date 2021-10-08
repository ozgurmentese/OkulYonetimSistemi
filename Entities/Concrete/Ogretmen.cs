using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class Ogretmen : IEntity
    {
        public int Id { get; set; }
        public int BolumId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public char Cinsiyet { get; set; }
    }
}
