using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OkulUI.Models.Ogretmen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OkulUI.Controllers
{
    public class OgretmenController : Controller
    {
        private readonly IOgrenciService _ogrenciService;
        private readonly IOgretmenService _ogretmenService;
        OkulContext _context;

        public OgretmenController(IOgrenciService ogrenciService, IOgretmenService ogretmenService)
        {
            _ogrenciService = ogrenciService;
            _ogretmenService = ogretmenService;
            _context = new OkulContext();
        }

        public IActionResult GetAll()
        {
            var model = new OgretmenListModel
            {
                OgretmenOgrenciSayilari = _ogretmenService.OgretmenOgrenciSayisi().Data
            };

            return View(model.OgretmenOgrenciSayilari);
        }

        public IActionResult Create()
        {
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
        public IActionResult Create(Ogretmen ogretmen)
        {
            var model = new OgretmenCreateModel
            {
                Ogretmen = ogretmen
            };
            var result = _ogretmenService.Add(model.Ogretmen);
            if (result.Success)
            {
                return RedirectToAction("GetAll");
            }

            return View();
        }

        public IActionResult Delete(int ogretmenId)
        {
            var ogretmen = _ogretmenService.GetById(ogretmenId).Data;
            var result = _ogretmenService.Delete(ogretmen);
            if (result.Success)
            {
                return RedirectToAction("GetAll");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int ogretmenId)
        {
            var ogretmen = _ogretmenService.GetById(ogretmenId).Data;

            List<SelectListItem> bolumler = (from bolum in _context.Bolumler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = bolum.BolumAd,
                                                 Value = bolum.Id.ToString()
                                             }

                                                ).ToList();
            ViewBag.Bolumler = bolumler;

            return View(ogretmen);
        }

        [HttpPost]
        public IActionResult Update(Ogretmen ogretmen)
        {
            var model = new OgretmenCreateModel
            {
                Ogretmen = ogretmen
            };
            var result = _ogretmenService.Update(model.Ogretmen);
            if (result.Success)
            {
                return RedirectToAction("GetAll");
            }
            return View();
        }


    }
}
