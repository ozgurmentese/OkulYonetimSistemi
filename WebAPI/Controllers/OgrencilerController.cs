using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OgrencilerController : ControllerBase
    {
        private readonly IOgrenciService _ogrenciService;

        public OgrencilerController(IOgrenciService ogrenciService)
        {
            _ogrenciService = ogrenciService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _ogrenciService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getgrenciogretmen")]
        public IActionResult GetOgrenciOgretmen()
        {
            var result = _ogrenciService.GetOgrenciOgretmen();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _ogrenciService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
                
        [HttpPost("add")]
        public IActionResult Add(Ogrenci ogrenci)
        {
            var result = _ogrenciService.Add(ogrenci);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
                
        [HttpPost("delete")]
        public IActionResult Delete(Ogrenci ogrenci)
        {
            var result = _ogrenciService.Delete(ogrenci);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
                        
        [HttpPost("update")]
        public IActionResult Update(Ogrenci ogrenci)
        {
            var result = _ogrenciService.Update(ogrenci);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
