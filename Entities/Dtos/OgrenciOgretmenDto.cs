using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class OgrenciOgretmenDto:IDto
    {
        public int OgrenciId { get; set; }
        public string OgrenciAd { get; set; }
        public string OgrenciSoyad { get; set; }
        public int OgrenciYas { get; set; }
        public char OgrenciCinsiyet { get; set; }
        public string OgretmenAd { get; set; }
        public string OgretmenSoyad { get; set; }
    }
}
