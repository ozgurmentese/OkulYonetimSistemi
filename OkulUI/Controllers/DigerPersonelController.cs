using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OkulUI.Controllers
{
    public class DigerPersonelController : Controller
    {
        private readonly IDigerPersonelService _digerPersonelService;
        OkulContext _context;

        public DigerPersonelController(IDigerPersonelService digerPersonelService)
        {
            _digerPersonelService = digerPersonelService;
            _context = new OkulContext();
        }

        public IActionResult GetAll()
        {
            var model = _digerPersonelService.GetAll();
            if (model.Success)
            {
                return View(model.Data);
            }
            return View();
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
        public IActionResult Create(DigerPersonel digerPersonel)
        {
            var result = _digerPersonelService.Add(digerPersonel);
            if (result.Success)
            {
                return RedirectToAction("GetAll");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Update(int digerPersonelId)
        {
            List<SelectListItem> bolumler = (from bolum2 in _context.Bolumler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = bolum2.BolumAd,
                                                 Value = bolum2.Id.ToString()
                                             }

                                              ).ToList();
            ViewBag.Bolumler = bolumler;

            var bolum = _digerPersonelService.GetById(digerPersonelId).Data;
            return View(bolum);
        }

        [HttpPost]
        public IActionResult Update(DigerPersonel digerPersonelId)
        {
            var result = _digerPersonelService.Update(digerPersonelId);
            if (result.Success)
            {
                return RedirectToAction("GetAll");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var bolum = _digerPersonelService.GetById(id).Data;
            var result = _digerPersonelService.Delete(bolum);
            if (result.Success)
            {
                return RedirectToAction("GetAll");
            }
            return View();
        }

    }
}
