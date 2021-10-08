using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OkulUI.Models.Ogrenci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OkulUI.Controllers
{
    public class OgrenciController : Controller
    {
        private readonly IOgrenciService _ogrenciService;
        private readonly IOgretmenService _ogretmenService;

        OkulContext _context;

        public OgrenciController(IOgrenciService ogrenciService, IOgretmenService ogretmenService)
        {
            _ogrenciService = ogrenciService;
            _ogretmenService = ogretmenService;
            _context = new OkulContext();
        }

        public IActionResult GetAll()
        {
            var model = new OgrenciListModel
            {
                Ogrenciler = _ogrenciService.GetOgrenciOgretmen().Data
            };

            return View(model);
        }

        public IActionResult Create()
        {
            List<SelectListItem> ogretmenler = (from ogr in _context.Ogretmenler.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = ogr.Ad + " " + ogr.Soyad,
                                                    Value = ogr.Id.ToString()
                                                }

                                                ).ToList();
            ViewBag.Ogretmenler = ogretmenler;

            List<SelectListItem> bolumler = (from bolum in _context.Bolumler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = bolum.BolumAd,
                                                 Value = bolum.Id.ToString()
                                             }

                                                ).ToList();
            ViewBag.Bolumler = bolumler;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Ogrenci ogrenci)
        {
            var model = new OgrenciCreateModel
            {
                Ogrenci = ogrenci
            };
            var result = _ogrenciService.Add(model.Ogrenci);
            if (result.Success)
            {
                return RedirectToAction("GetAll");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int ogrenciId)
        {
            var ogrenci = _ogrenciService.GetById(ogrenciId).Data;

            List<SelectListItem> ogretmenler = (from ogr in _context.Ogretmenler.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = ogr.Ad + " " + ogr.Soyad,
                                                    Value = ogr.Id.ToString()
                                                }

                                                ).ToList();
            ViewBag.Ogretmenler = ogretmenler;

            List<SelectListItem> bolumler = (from bolum in _context.Bolumler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = bolum.BolumAd,
                                                 Value = bolum.Id.ToString()
                                             }

                                                ).ToList();
            ViewBag.Bolumler = bolumler;

            return View(ogrenci);
        }

        [HttpPost]
        public IActionResult Update(Ogrenci ogrenci)
        {
            var model = new OgrenciCreateModel
            {
                Ogrenci = ogrenci
            };
            var result = _ogrenciService.Update(model.Ogrenci);
            if (result.Success)
            {
                return RedirectToAction("GetAll");
            }
            return View();
        }

        public IActionResult Delete(int ogrenciId)
        {
            var ogrenci = _ogrenciService.GetById(ogrenciId).Data;
            var result = _ogrenciService.Delete(ogrenci);
            if (result.Success)
            {
                return RedirectToAction("GetAll");
            }
            return View();
        }

    }
}
