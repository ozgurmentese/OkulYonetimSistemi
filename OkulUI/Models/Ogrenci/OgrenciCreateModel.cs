using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OkulUI.Models.Ogrenci
{
    public class OgrenciCreateModel
    {
        public Entities.Concrete.Ogrenci Ogrenci { get; set; }
        public List<Entities.Concrete.Ogretmen> Ogretmenler { get; set; }
        //public List<Bolum> Bolumler { get; set; }
    }
}
