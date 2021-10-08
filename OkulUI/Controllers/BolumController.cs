using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OkulUI.Controllers
{
    public class BolumController : Controller
    {
        private readonly IBolumService _bolumService;

        public BolumController(IBolumService bolumService)
        {
            _bolumService = bolumService;
        }

        public IActionResult GetAll()
        {
            var model = _bolumService.GetAll().Data;
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Bolum bolum)
        {
            var result = _bolumService.Add(bolum);
            if (result.Success)
            {
                return RedirectToAction("GetAll");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int bolumId)
        {
            var bolum = _bolumService.GetById(bolumId).Data;
            return View(bolum);
        }

        [HttpPost]
        public IActionResult Update(Bolum bolum)
        {
            var result = _bolumService.Update(bolum);
            if (result.Success)
            {
                return RedirectToAction("GetAll");
            }
            return View();
        }

        public IActionResult Delete(int bolumId)
        {
            var bolum = _bolumService.GetById(bolumId).Data;
            var result = _bolumService.Delete(bolum);
            if (result.Success)
            {
                return RedirectToAction("GetAll");
            }
            return View();
        }
    }
}
