using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Entities.Dtos;

namespace OkulUI.Models.Ogrenci
{
    public class OgrenciListModel
    {
        public List<OgrenciOgretmenDto> Ogrenciler { get; set; }
    }
}
