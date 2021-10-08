using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OkulUI.Models.Ogretmen
{
    public class OgretmenCreateModel
    {
        public Entities.Concrete.Ogretmen Ogretmen { get; set; }
        public List<Entities.Concrete.Ogrenci> Ogrenciler { get; set; }
    }
}
