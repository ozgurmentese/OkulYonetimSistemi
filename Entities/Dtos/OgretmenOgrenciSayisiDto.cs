using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class OgretmenOgrenciSayisiDto:IDto
    {
        public int OgretmenId { get; set; }
        public string OgretmenAd { get; set; }
        public string OgretmenSoyad { get; set; }
        public int Yas { get; set; }
        public char Cinsiyet { get; set; }
        public int? OgrenciSayisi { get; set; }
    }
}
